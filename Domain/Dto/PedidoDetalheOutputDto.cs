namespace Domain.Dto
{
    public class PedidoDetalheOutputDto
    {
        public string? CaixaId { get; set; }
        public required List<string> Produtos { get; set; }
        public string? Observacao { get; set; }
    }
}
