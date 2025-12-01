using LibraryCore.Domain.Entities;
using LibraryCore.Services.Interfaces;

namespace LibraryCore.Infrastructure.External;

public class RecomendacaoServiceIA : IRecomendacaoService
{
    public string ObterSugestaoBaseadaEmIA(Usuario usuario)
    {
        return "O Senhor dos Anéis (Sugestão via IA)";
    }
}
