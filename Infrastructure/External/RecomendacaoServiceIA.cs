using LibraryCore.Domain.Entities;
using LibraryCore.Services.Interfaces;
using LibraryCore.Domain.Enums;

namespace LibraryCore.Infrastructure.External;

public class RecomendacaoServiceIA : IRecomendacaoService
{
    public string ObterSugestaoBaseadaEmIA(Usuario usuario)
    {
        var sugestoes = new[]
        {
            "Design Patterns (Gof)",
            "Domain-Driven Design",
            "Refactoring",
            "Harry Potter",
            "Sherlock Holmes"
        };

        var random = new Random();
        return sugestoes[random.Next(sugestoes.Length)];
    }

    public string SugerirBaseadoNoLivroAtual(Livro livro)
    {
        return livro.Genero switch
        {
            GeneroEnum.Fantasia => "Senhor dos Anéis",
            GeneroEnum.Suspense => "O Código Da Vinci",
            GeneroEnum.Drama => "A Menina que Roubava Livros",
            _ => "Clean Architecture"
        };
    }
}