namespace Domain.Dto
{
    public class ResultadoEmpacotamentoDto
    {
        public int PedidoId { get; set; }
        public List<CaixaResultadoDto> Caixas { get; set; }
    }
}
