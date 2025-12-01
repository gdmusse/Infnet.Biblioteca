using LibraryCore.Domain.Enums;

namespace LibraryCore.Domain.Entities;

public class Notificacao
{
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public MetodoContatoEnum Metodo { get; private set; }

    public Notificacao(string descricao, MetodoContatoEnum metodo)
    {
        Descricao = descricao;
        Metodo = metodo;
    }
}
