using FluentValidation;

namespace Application.Commands.Validation
{
    public class PedidosCommandValidation : AbstractValidator<PedidosCommand>
    {
        public PedidosCommandValidation()
        {
            RuleFor(u => u.Input.Count)
                .NotEmpty()
                .WithMessage("Pedidos não informados");
        }
    }
}
