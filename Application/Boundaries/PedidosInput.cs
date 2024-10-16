using Domain.Entities;

namespace Application.Boundaries
{
    public class PedidosInput
    {
        public int Pedido_id { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
