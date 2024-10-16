using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using MediatR;
using Application.Mapper;
using Application.Commands;
using Application.UseCases.Interface;

namespace Application.Handlers
{
    public class PedidosHandler(IPedidosUseCase useCase,
                                IMessagesHandler messagesHandler
    ) :
        IRequestHandler<PedidosCommand, bool>
    {
        private readonly IPedidosUseCase _useCase = useCase;
        private readonly IMessagesHandler _messagesHandler = messagesHandler;

        public async Task<bool> Handle(PedidosCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var dto = command.Input.MapToDto();
                var empacotamentoDtos = await _useCase.CaulcularCaixasAsync(dto).ConfigureAwait(false);
                command.Output = empacotamentoDtos.MapDtoToOutput();
                return true;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _messagesHandler.SendDomainNotificationAsync(new DomainNotification
                (
                    command.MessageType,
                    error.ErrorMessage
                )).ConfigureAwait(false);
            }

            return false;
        }
    }
}
