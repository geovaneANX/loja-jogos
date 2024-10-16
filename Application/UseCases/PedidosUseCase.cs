using Application.Services.Interface;
using Application.UseCases.Interface;
using Domain.Dto;
using Microsoft.Extensions.Logging;

namespace Application.UseCases
{
    public class PedidosUseCase(ILogger<PedidosUseCase> logger,
                                IPedidosService service
    ) : 
        IPedidosUseCase
    {
        public List<PedidoOutputDto> CaulcularCaixas(List<PedidosDto> dto)
        {
            var caixasUsadas = service.EmpacotarPedidos(dto).Result;
            return caixasUsadas;
        }
    }

}
