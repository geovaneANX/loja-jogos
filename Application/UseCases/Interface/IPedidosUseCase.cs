using Domain.Dto;

namespace Application.UseCases.Interface
{
    public interface IPedidosUseCase
    {
        List<PedidoOutputDto> CaulcularCaixas(List<PedidosDto> dto);
    }
}
