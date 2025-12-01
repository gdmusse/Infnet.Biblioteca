using LibraryCore.Domain.Enums;

namespace LibraryCore.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public TipoDeUsuarioEnum TipoUsuario { get; private set; }

    public Usuario(int id, string nome, string email, TipoDeUsuarioEnum tipo)
    {
        Id = id;
        Nome = nome;
        Email = email;
        TipoUsuario = tipo;
    }
}
