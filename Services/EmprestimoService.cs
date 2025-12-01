using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;
using LibraryCore.Domain.Interfaces;
using LibraryCore.Services.Interfaces;
using LibraryCore.Patterns.Strategy;

namespace LibraryCore.Services;

// Princípio SOLID: SRP (Single Responsibility Principle)
// Objetivo: Uma classe deve ter apenas um motivo para mudar.
// Aplicação: Esta classe cuida apenas da regra de negócio do empréstimo. Não envia e-mail, não acessa banco.
public class EmprestimoService
{
    private readonly IEstoqueRepository _estoqueRepo;
    private readonly INotificacaoService _notificacaoService;
    private readonly IRecomendacaoService _recomendacaoService;

    // PRINCÍPIOS SOLID: DIP (Dependency Inversion Principle)
    // Objetivo: Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.
    // Aplicação: Injeta interfaces e não as classes concretas.
    public EmprestimoService(
        IEstoqueRepository estoqueRepo, 
        INotificacaoService notificacaoService,
        IRecomendacaoService recomendacaoService)
    {
        _estoqueRepo = estoqueRepo;
        _notificacaoService = notificacaoService;
        _recomendacaoService = recomendacaoService;
    }

    public void RealizarEmprestimo(Usuario usuario, Livro livro)
    {
        var estoque = _estoqueRepo.ObterPorLivro(livro.Id);
        
        // Clean Code: Evitando aninhamento (Guard Clause)
        if (!estoque.PossuiDisponibilidade())
            throw new Exception("Livro indisponível");

        // Clean Code: Evitando condicionais complexas
        IRegraEmprestimoStrategy estrategia = usuario.TipoUsuario == TipoDeUsuarioEnum.Professor 
            ? new EstrategiaProfessor() 
            : new EstrategiaEstudante();

        var dataDevolucao = estrategia.CalcularDevolucao(DateTime.Now);

        // 3. Persistência
        estoque.DebitarEstoque();
        _estoqueRepo.Atualizar(estoque);
        
        var emprestimo = new Emprestimo(usuario, livro, dataDevolucao);
        Console.WriteLine($"[SUCESSO] Empréstimo criado. Devolução: {emprestimo.DataDevolucao.ToShortDateString()}");

        _notificacaoService.Notificar($"Empréstimo confirmado: {livro.Nome}", usuario.Email);
        
        var sugestao = _recomendacaoService.ObterSugestaoBaseadaEmIA(usuario);
        Console.WriteLine($"[IA RECOMENDA]: Que tal ler '{sugestao}' a seguir?");
    }
}
