using Next3.Domain.Validations;
using System;

namespace Next3.Domain.Commands
{
    public class RemoveOrderCommand : OrderCommand
    {
        public RemoveOrderCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
