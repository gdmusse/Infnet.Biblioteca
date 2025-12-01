namespace LibraryCore.Patterns.Strategy;

// PADRÃO DE PROJETO COMPORTAMENTAL - STRATEGY
// Objetivo: Definir uma família de algoritmos, encapsular e tornar eles intercambiáveis.
// Aplicação: Permite que o cálculo da data de devolução mude conforme o tipo de usuário sem usar IFs complexos.
public class EstrategiaEstudante : IRegraEmprestimoStrategy
{
    public DateTime CalcularDevolucao(DateTime d) => d.AddDays(15);
}

public class EstrategiaProfessor : IRegraEmprestimoStrategy
{
    public DateTime CalcularDevolucao(DateTime d) => d.AddDays(30);
}
