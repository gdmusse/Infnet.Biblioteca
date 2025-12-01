using LibraryCore.Domain.Entities;

namespace LibraryCore.Services.Interfaces;

public interface IRecomendacaoService
{
    string ObterSugestaoBaseadaEmIA(Usuario usuario);
}
