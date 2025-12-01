namespace LibraryCore.Patterns.Strategy;

public interface IRegraEmprestimoStrategy
{
    DateTime CalcularDevolucao(DateTime dataInicio);
}
