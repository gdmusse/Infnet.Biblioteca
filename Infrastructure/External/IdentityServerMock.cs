using System.Collections.Generic;
using System.Linq;
using LibraryCore.Domain.Entities;
using LibraryCore.Domain.Enums;

namespace LibraryCore.Infrastructure.External;

public class IdentityServiceMock
{
    private static readonly List<Usuario> _usuarios = new()
    {
        new Usuario(1, "Ana", "ana@edu.br", TipoDeUsuarioEnum.Estudante),
        new Usuario(2, "Prof. Carlos", "carlos@univ.br", TipoDeUsuarioEnum.Professor),
        new Usuario(3, "Beatriz", "bia@edu.br", TipoDeUsuarioEnum.Estudante)
    };

    public List<Usuario> ObterTodosUsuarios() => _usuarios;

    public Usuario? ObterUsuarioPorId(int id)
    {
        return _usuarios.FirstOrDefault(u => u.Id == id);
    }
}