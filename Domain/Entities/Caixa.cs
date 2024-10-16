namespace Domain.Entities
{
    public class Caixa
    {
        public string CaixaId { get; set; }
        public Dimensoes Dimensoes { get; set; }

        private Caixa(string caixaId, Dimensoes dimensoes)
        {
            CaixaId = caixaId;
            Dimensoes = dimensoes;
        }

        public static Caixa Create(string caixaId, Dimensoes dimensoes)
        {
            return new Caixa(caixaId, dimensoes);
        }

        public static readonly List<Caixa> CaixasDisponiveis =
        [
            Create("Caixa 1", new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 }),
            Create("Caixa 2", new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 }),
            Create("Caixa 3", new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 })
        ];
    }
}
