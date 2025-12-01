using LibraryCore.Domain.Enums;

namespace LibraryCore.Domain.Entities;

public class Emprestimo
{
    public int Id { get; private set; }
    public Usuario Usuario { get; private set; }
    public Livro Livro { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime? DataFim { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public StatusEnum Status { get; private set; }

    public Emprestimo(Usuario usuario, Livro livro, DateTime devolucao)
    {
        Usuario = usuario;
        Livro = livro;
        DataInicio = DateTime.Now;
        DataDevolucao = devolucao;
        Status = StatusEnum.Ativo;
    }
}
