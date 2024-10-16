using Domain.Dto;

namespace Application.UseCases.Interface
{
    public interface IPedidosUseCase
    {
        Task<List<ResultadoEmpacotamentoDto>> CaulcularCaixasAsync(List<PedidosDto> dto);
    }
}
