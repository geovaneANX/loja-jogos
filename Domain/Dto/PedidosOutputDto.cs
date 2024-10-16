using Domain.Entities;

namespace Domain.Dto
{
    public class PedidosOutputDto
    {
        public int Id { get; set; }
        public List<Caixa> Caixas { get; set; }
    }
}
