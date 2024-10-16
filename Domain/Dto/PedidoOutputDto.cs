namespace Domain.Dto
{
    public class PedidoOutputDto
    {
        public int PedidoId { get; set; }
        public required List<PedidoDetalheOutputDto> Caixas { get; set; }
    }
}
