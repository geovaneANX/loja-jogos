using FluentValidation.Results;
using MediatR;

namespace Infrastructure.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}