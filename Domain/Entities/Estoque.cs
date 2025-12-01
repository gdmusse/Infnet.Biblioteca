namespace LibraryCore.Domain.Entities;

public class Estoque
{
    public Livro Livro { get; private set; }
    public int Quantidade { get; private set; }

    public Estoque(Livro livro, int quantidade)
    {
        Livro = livro;
        Quantidade = quantidade;
    }

    // Clean Code: Nome significativo
    public bool PossuiDisponibilidade() => Quantidade > 0;

    public void DebitarEstoque()
    {
        // Clean Code: Fail Fast
        if (!PossuiDisponibilidade()) throw new InvalidOperationException("Estoque vazio");
        Quantidade--;
    }
}
