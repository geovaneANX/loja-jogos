using Domain.Entities;

namespace Domain.Dto
{
    public class PedidosDto
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
