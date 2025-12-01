using LibraryCore.Services.Interfaces;
using LibraryCore.Infrastructure.External;

namespace LibraryCore.Infrastructure.Adapters;

// PADRÃO DE PROJETO ESTRUTURAL - ADAPTER
public class PushNotificationAdapter : INotificacaoService
{
    private readonly ThirdPartyPushApi _apiExterna;

    public PushNotificationAdapter(ThirdPartyPushApi apiExterna)
    {
        _apiExterna = apiExterna;
    }

    public void Notificar(string mensagem, string destinatario)
    {
        _apiExterna.SendPushMessage(destinatario, mensagem);
    }
}
