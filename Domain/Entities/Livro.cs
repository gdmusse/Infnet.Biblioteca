using System;
using LibraryCore.Domain.Enums;

namespace LibraryCore.Domain.Entities;

public class Livro
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public GeneroEnum Genero { get; private set; }
    public Autor Autor { get; private set; }

    public Livro(int id, string nome, GeneroEnum genero, Autor autor)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório");
        Id = id;
        Nome = nome;
        Genero = genero;
        Autor = autor;
    }
}
