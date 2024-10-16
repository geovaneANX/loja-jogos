using Application.Boundaries;
using Application.Commands;
using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : BaseController<PedidosController>
    {
        private readonly IMessagesHandler _messagesHandler;

        public PedidosController(IMessagesHandler messagesHandler,
                                 INotificationHandler<DomainNotification> notifications
        ) : 
            base(notifications, messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        [HttpPost("CalcularCaixas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalcularCaixas(List<PedidosInput> input)
        {
            PedidosCommand pedidosCommand = new() { Input = input };
            await _messagesHandler.SendCommandAsync(pedidosCommand).ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status200OK, pedidosCommand.Output);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }
    }
}