using System.Collections.Generic;
using System.Linq;
using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;

namespace LibraryCore.Infrastructure.Repositories;

public class LivroRepositoryMock
{
    private static readonly List<Livro> _livros;

    static LivroRepositoryMock()
    {
        var autor1 = new Autor(1, "Robert C. Martin");
        var autor2 = new Autor(2, "J.R.R. Tolkien");
        var autor3 = new Autor(3, "Agatha Christie");

        _livros = new List<Livro>
        {
            new Livro(1, "Clean Code", GeneroEnum.Educativo, autor1),
            new Livro(2, "O Hobbit", GeneroEnum.Fantasia, autor2),
            new Livro(3, "Assassinato no Expresso", GeneroEnum.Suspense, autor3),
            new Livro(4, "Arquitetura Limpa", GeneroEnum.Educativo, autor1)
        };
    }

    public List<Livro> ObterTodos() => _livros;

    public Livro? ObterPorId(int id) => _livros.FirstOrDefault(l => l.Id == id);
}