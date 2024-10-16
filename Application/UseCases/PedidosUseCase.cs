using Application.Services.Interface;
using Application.UseCases.Interface;
using Domain.Dto;
using Infrastructure.Messages;
using Microsoft.Extensions.Logging;

namespace Application.UseCases
{
    public class PedidosUseCase : IPedidosUseCase
    {
        private readonly ILogger<PedidosUseCase> _logger;
        private readonly IPedidosService _service;

        public PedidosUseCase(ILogger<PedidosUseCase> logger,
                              IPedidosService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<List<ResultadoEmpacotamentoDto>> CaulcularCaixasAsync(List<PedidosDto> dto)
        {
            var caixasUsadas = _service.EmpacotarPedidos(dto).Result;
            return caixasUsadas;
        }
    }

}
