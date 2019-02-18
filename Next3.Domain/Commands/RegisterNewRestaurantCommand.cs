using Next3.Domain.Validations;
using System;

namespace Next3.Domain.Commands
{
    public class RegisterNewRestaurantCommand : RestaurantCommand
    {
        public RegisterNewRestaurantCommand(string name, string description, bool isActive, Guid expertiseId, Guid addressId)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            ExpertiseId = expertiseId;
            AddressId = addressId;

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRestaurantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
