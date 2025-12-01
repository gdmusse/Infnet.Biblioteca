namespace LibraryCore.Patterns.Strategy;

// PADRÃO DE PROJETO COMPORTAMENTAL - STRATEGY
public class EstrategiaEstudante : IRegraEmprestimoStrategy
{
    public DateTime CalcularDevolucao(DateTime d) => d.AddDays(15);
}

public class EstrategiaProfessor : IRegraEmprestimoStrategy
{
    public DateTime CalcularDevolucao(DateTime d) => d.AddDays(30);
}
