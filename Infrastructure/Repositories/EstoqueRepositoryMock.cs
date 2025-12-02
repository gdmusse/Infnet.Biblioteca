using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Interfaces;

namespace LibraryCore.Infrastructure.Repositories;

public class EstoqueRepositoryMock : IEstoqueRepository
{
    private static readonly List<Estoque> _bancoDeEstoque = new();

    public EstoqueRepositoryMock()
    {
        if (!_bancoDeEstoque.Any())
        {
            var livroRepo = new LivroRepositoryMock();
            var livros = livroRepo.ObterTodos();

            foreach (var livro in livros)
            {
                _bancoDeEstoque.Add(new Estoque(livro, 2));
            }
        }
    }

    public Estoque ObterPorLivro(int livroId)
    {
        return _bancoDeEstoque.FirstOrDefault(e => e.Livro.Id == livroId);
    }

    public void Atualizar(Estoque estoque)
    {
        Console.WriteLine($"[DB UPDATE] Livro: {estoque.Livro.Nome} | Novo Saldo: {estoque.Quantidade}");
    }
}