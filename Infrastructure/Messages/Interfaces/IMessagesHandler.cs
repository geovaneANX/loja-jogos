namespace Infrastructure.Messages.Interfaces
{
    public interface IMessagesHandler
    {
        Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command;
        Task SendDomainNotificationAsync<TDomainNotification>(TDomainNotification notificacao) where TDomainNotification : DomainNotification;
    }
}