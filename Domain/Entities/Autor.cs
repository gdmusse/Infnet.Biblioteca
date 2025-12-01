namespace LibraryCore.Domain.Entities;

public class Autor
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    public Autor(int id, string nome)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome do autor é obrigatório");
        Id = id;
        Nome = nome;
    }
}
