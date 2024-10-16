using Domain.Dto;

namespace Application.Services.Interface
{
    public interface IPedidosService
    {
        Task<List<ResultadoEmpacotamentoDto>> EmpacotarPedidos(List<PedidosDto> pedidos);
    }
}
