using Application.Boundaries;
using Application.Commands.Validation;
using Infrastructure.Messages;

namespace Application.Commands
{
    public class PedidosCommand : Command
    {
        public PedidosCommand() { }

        public List<PedidosInput> Input { get; set; }

        public object Output { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new PedidosCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
