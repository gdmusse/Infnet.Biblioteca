using LibraryCore.Services.Interfaces;
using LibraryCore.Infrastructure.External;

namespace LibraryCore.Infrastructure.Adapters;

// PADRÃO DE PROJETO ESTRUTURAL - ADAPTER
// Objetivo: Permitir que classes com interfaces incompatíveis trabalhem juntas.
// Aplicação: Adapta-se a chamada da "ThirdPartyPushApi" para a interface "INotificacaoService" do domínio.
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
