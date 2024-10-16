using Domain.Dto;

namespace Application.Services.Interface
{
    public interface IPedidosService
    {
        Task<List<PedidoOutputDto>> EmpacotarPedidos(List<PedidosDto> pedidos);
    }
}
