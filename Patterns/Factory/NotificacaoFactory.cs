using LibraryCore.Domain.Enums;
using LibraryCore.Services.Interfaces;
using LibraryCore.Infrastructure.External;
using LibraryCore.Infrastructure.Adapters;

namespace LibraryCore.Patterns.Factory;

// PADRÃO DE PROJETO CRIACIONAL - FACTORY METHOD (Variação Simple Factory)
public static class NotificacaoFactory
{
    public static INotificacaoService Criar(MetodoContatoEnum metodo)
    {
        return metodo switch
        {
            MetodoContatoEnum.Email => new EmailService(),
            MetodoContatoEnum.Push => new PushNotificationAdapter(new ThirdPartyPushApi()),
            _ => new EmailService()
        };
    }
}
