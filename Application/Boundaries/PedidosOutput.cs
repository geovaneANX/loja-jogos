using Domain.Dto;

namespace Application.Boundaries
{
    public class PedidosOutput
    {
        public int PedidoId { get; set; }
        public required List<CaixaResultadoDto> Caixas { get; set; }
    }
}
