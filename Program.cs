using System;
using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;
using LibraryCore.Domain.Interfaces;
using LibraryCore.Services;
using LibraryCore.Services.Interfaces;
using LibraryCore.Infrastructure.Repositories;
using LibraryCore.Infrastructure.External;
using LibraryCore.Patterns.Factory;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");

        var autor = new Autor(1, "Robert C. Martin");
        var livro = new Livro(1, "Clean Code", GeneroEnum.Fantasia, autor);
        var usuario = new Usuario(1, "João", "joao@email.com", TipoDeUsuarioEnum.Estudante);

        var metodoEscolhido = MetodoContatoEnum.Push; 

        // Pattern Factory
        INotificacaoService notificacao = NotificacaoFactory.Criar(metodoEscolhido);
        
        IEstoqueRepository repo = new EstoqueRepositoryMock();
        IRecomendacaoService aiService = new RecomendacaoServiceIA();

        var service = new EmprestimoService(repo, notificacao, aiService);

        try 
        {
            service.RealizarEmprestimo(usuario, livro);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro de Negócio: {ex.Message}");
        }
    }
}
