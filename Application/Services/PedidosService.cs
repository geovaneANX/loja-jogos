using Application.Services.Interface;
using Domain.Dto;
using Domain.Entities;

namespace Application.Services
{
    public class PedidosService: IPedidosService
    {
        public Task<List<ResultadoEmpacotamentoDto>> EmpacotarPedidos(List<PedidosDto> pedidos)
        {
            var resultado = new List<ResultadoEmpacotamentoDto>();

            foreach (var pedido in pedidos)
            {
                var caixasUsadas = EmpacotarProdutos(pedido.Produtos);
                resultado.Add(new ResultadoEmpacotamentoDto
                {
                    PedidoId = pedido.Id,
                    Caixas = caixasUsadas
                });
            }

            return Task.FromResult(resultado);
        }

        private List<CaixaResultadoDto> EmpacotarProdutos(List<Produto> produtos)
        {
            var caixasUsadas = new List<CaixaResultadoDto>();

            // Ordenar produtos por volume, do maior para o menor
            var produtosOrdenados = produtos.OrderByDescending(p => CalcularVolume(p.Dimensoes)).ToList();

            foreach (var caixa in Caixa.CaixasDisponiveis.OrderBy(c => CalcularVolume(c.Dimensoes)))
            {
                var produtosNaCaixa = new List<string>();
                var volumeCaixaDisponivel = CalcularVolume(caixa.Dimensoes);
                var capacidadeRestante = volumeCaixaDisponivel;

                // Verificar quais produtos cabem na caixa
                for (int i = produtosOrdenados.Count - 1; i >= 0; i--)
                {
                    var produto = produtosOrdenados[i];
                    var volumeProduto = CalcularVolume(produto.Dimensoes);

                    if (volumeProduto <= capacidadeRestante && ProdutoCabeNaCaixa(produto, caixa))
                    {
                        produtosNaCaixa.Add(produto.Produto_id);
                        capacidadeRestante -= volumeProduto;
                        produtosOrdenados.RemoveAt(i);
                    }
                }

                if (produtosNaCaixa.Count != 0)
                {
                    caixasUsadas.Add(new CaixaResultadoDto
                    {
                        CaixaId = caixa.CaixaId,
                        Produtos = produtosNaCaixa
                    });
                }
            }

            // Se ainda restam produtos que não cabem nas caixas disponíveis
            if (produtosOrdenados.Count != 0)
            {
                foreach (var produto in produtosOrdenados)
                {
                    caixasUsadas.Add(new CaixaResultadoDto
                    {
                        CaixaId = null,
                        Produtos = [produto.Produto_id],
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }
            }

            return caixasUsadas;
        }

        private static bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            // Verifica se o produto pode caber em qualquer orientação
            var dimensoesProduto = new[] { produto.Dimensoes.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento };
            var dimensoesCaixa = new[] { caixa.Dimensoes.Altura, caixa.Dimensoes.Largura, caixa.Dimensoes.Comprimento };

            return PodeRotacionarEEncaixar(dimensoesProduto, dimensoesCaixa);
        }

        private static bool PodeRotacionarEEncaixar(int[] dimensoesProduto, int[] dimensoesCaixa)
        {
            // Tenta todas as combinações de rotação (6 combinações de altura, largura e comprimento)
            var orientacoesProduto = new[]
            {
            new[] { dimensoesProduto[0], dimensoesProduto[1], dimensoesProduto[2] },
            new[] { dimensoesProduto[0], dimensoesProduto[2], dimensoesProduto[1] },
            new[] { dimensoesProduto[1], dimensoesProduto[0], dimensoesProduto[2] },
            new[] { dimensoesProduto[1], dimensoesProduto[2], dimensoesProduto[0] },
            new[] { dimensoesProduto[2], dimensoesProduto[0], dimensoesProduto[1] },
            new[] { dimensoesProduto[2], dimensoesProduto[1], dimensoesProduto[0] }
        };

            foreach (var orientacao in orientacoesProduto)
            {
                if (orientacao[0] <= dimensoesCaixa[0] &&
                    orientacao[1] <= dimensoesCaixa[1] &&
                    orientacao[2] <= dimensoesCaixa[2])
                {
                    return true;
                }
            }

            return false;
        }

        private int CalcularVolume(Dimensoes dimensoes)
        {
            return dimensoes.Altura * dimensoes.Largura * dimensoes.Comprimento;
        }
    }
}
