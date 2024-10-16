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
        public async Task<bool> Handle(PedidosCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var dto = command.Input.MapToDto();
                var empacotamentoDtos = useCase.CaulcularCaixas(dto);
                command.Output = empacotamentoDtos.MapDtoToOutput();
                return true;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await messagesHandler.SendDomainNotificationAsync(new DomainNotification
                (
                    command.MessageType,
                    error.ErrorMessage
                )).ConfigureAwait(false);
            }

            return false;
        }
    }
}
