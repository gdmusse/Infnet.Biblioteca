using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;
using LibraryCore.Domain.Interfaces;

namespace LibraryCore.Infrastructure.Repositories;

public class EstoqueRepositoryMock : IEstoqueRepository
{
    public Estoque ObterPorLivro(int livroId)
    {
        var autorMock = new Autor(1, "Autor Mock");
        var livroMock = new Livro(livroId, "Livro Simulado do Banco", GeneroEnum.Fantasia, autorMock);

        return new Estoque(livroMock, 5);
    }

    public void Atualizar(Estoque estoque)
    {
        Console.WriteLine($"[DB] Estoque do livro '{estoque.Livro.Nome}' atualizado. Nova quantidade: {estoque.Quantidade}");
    }
}