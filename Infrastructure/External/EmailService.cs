using LibraryCore.Services.Interfaces;

namespace LibraryCore.Infrastructure.External;

public class EmailService : INotificacaoService
{
    public void Notificar(string msg, string dest) => 
        Console.WriteLine($"[EMAIL] Enviado para {dest}: {msg}");
}
