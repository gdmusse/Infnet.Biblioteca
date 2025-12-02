using System;
using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;
using LibraryCore.Domain.Interfaces;
using LibraryCore.Services;
using LibraryCore.Services.Interfaces;
using LibraryCore.Infrastructure.Repositories;
using LibraryCore.Infrastructure.External;
using LibraryCore.Infrastructure.Adapters;
using LibraryCore.Patterns.Factory;

class Program
{
    static void Main(string[] args)
    {
        var identityService = new IdentityServiceMock();
        var livroRepoMock = new LivroRepositoryMock(); 

        IEstoqueRepository estoqueRepo = new EstoqueRepositoryMock();
        IRecomendacaoService aiService = new RecomendacaoServiceIA();

        var metodoNotificacao = MetodoContatoEnum.Push;
        INotificacaoService notificacaoService = NotificacaoFactory.Criar(metodoNotificacao);

        var emprestimoService = new EmprestimoService(estoqueRepo, notificacaoService, aiService);

        bool rodando = true;
        while (rodando)
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("      SISTEMA DE BIBLIOTECA - LOJANOVA CLOUD     ");
            Console.WriteLine("=================================================");
            Console.WriteLine("1. Realizar Novo Empréstimo");
            Console.WriteLine("2. Sair");
            Console.Write("Opção: ");

            var opcao = Console.ReadLine();

            if (opcao == "2") break;
            if (opcao == "1")
            {
                try
                {
                    RealizarFluxoEmprestimo(identityService, livroRepoMock, emprestimoService);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERRO] Falha ao processar: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void RealizarFluxoEmprestimo(
        IdentityServiceMock identity,
        LivroRepositoryMock livrosRepo,
        EmprestimoService service)
    {
        Console.WriteLine("\n--- PASSO 1: IDENTIFICAÇÃO DO USUÁRIO ---");
        var usuarios = identity.ObterTodosUsuarios();
        foreach (var u in usuarios)
        {
            Console.WriteLine($"ID: {u.Id} | Nome: {u.Nome} | Tipo: {u.TipoUsuario}");
        }

        Console.Write("Digite o ID do Usuário: ");
        if (!int.TryParse(Console.ReadLine(), out int userId)) throw new ArgumentException("ID Inválido");

        var usuarioSelecionado = identity.ObterUsuarioPorId(userId);
        if (usuarioSelecionado == null) throw new Exception("Usuário não encontrado na API de Identity.");
        Console.WriteLine($"-> Usuário selecionado: {usuarioSelecionado.Nome}");

        Console.WriteLine("\n--- PASSO 2: SELEÇÃO DO LIVRO ---");
        var livros = livrosRepo.ObterTodos();
        foreach (var l in livros)
        {
            // Busca o estoque apenas para mostrar na tela (UX)
            var estoqueRepo = new EstoqueRepositoryMock(); // Instancia temporária só para leitura visual
            var qtd = estoqueRepo.ObterPorLivro(l.Id).Quantidade;

            var statusStr = qtd > 0 ? $"{qtd} disponíveis" : "INDISPONÍVEL";
            Console.WriteLine($"ID: {l.Id} | Título: {l.Nome} ({l.Genero}) | [{statusStr}]");
        }

        Console.Write("Digite o ID do Livro: ");
        if (!int.TryParse(Console.ReadLine(), out int livroId)) throw new ArgumentException("ID Inválido");

        var livroSelecionado = livrosRepo.ObterPorId(livroId);
        if (livroSelecionado == null) throw new Exception("Livro não existe.");

        Console.WriteLine("\n--- PASSO 3: PROCESSAMENTO ---");
        Console.WriteLine("Calculando data e verificando regras...");

        service.RealizarEmprestimo(usuarioSelecionado, livroSelecionado);
    }
}