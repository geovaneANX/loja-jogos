using Infrastructure.Messages.Interfaces;
using MediatR;

namespace Infrastructure.Messages
{
    public class MessagesHandler : IMessagesHandler
    {
        private readonly IMediator _mediator;

        public MessagesHandler(IMediator mediator) => _mediator = mediator;

        public async Task<bool> SendCommandAsync<TCommand>(TCommand command)
            where TCommand : Command
        {
            return await _mediator.Send(command).ConfigureAwait(false);
        }

        public async Task SendDomainNotificationAsync<TDomainNotification>(TDomainNotification notificacao)
            where TDomainNotification : DomainNotification
        {
            await _mediator.Publish(notificacao).ConfigureAwait(false);
        }
    }
}