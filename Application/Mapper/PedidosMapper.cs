using Application.Boundaries;
using Domain.Dto;

namespace Application.Mapper
{
    internal static class PedidosMapper
    {
        internal static List<PedidosDto> MapToDto(this List<PedidosInput> input)
        {
            var listDto = new List<PedidosDto>();

            foreach (var pedido in input)
            {
                var dto = new PedidosDto
                {
                    Id = pedido.Pedido_id,
                    Produtos = pedido.Produtos
                };

                listDto.Add(dto);
            }

            return listDto;
        }

        internal static List<PedidosOutput> MapDtoToOutput(this List<PedidoOutputDto> dto)
        {
            var listOutput = new List<PedidosOutput>();

            foreach (var resultado in dto)
            {
                var output = new PedidosOutput
                {
                    PedidoId = resultado.PedidoId,
                    Caixas = resultado.Caixas
                };

                listOutput.Add(output);
            }

            return listOutput;
        }
    }
}
