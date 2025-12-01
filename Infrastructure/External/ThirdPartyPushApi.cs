namespace LibraryCore.Infrastructure.External;

public class ThirdPartyPushApi
{
    public void SendPushMessage(string token, string body)
    {
        Console.WriteLine($"[API EXTERNA PUSH] Enviando para Token: {token} | Conteúdo: {body}");
    }
}
