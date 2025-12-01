using LibraryCore.Domain.Entities;

namespace LibraryCore.Domain.Interfaces;

public interface IEstoqueRepository
{
    Estoque ObterPorLivro(int livroId);
    void Atualizar(Estoque estoque);
}
