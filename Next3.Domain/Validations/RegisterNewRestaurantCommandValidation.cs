using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class RegisterNewRestaurantCommandValidation : RestaurantValidation<RegisterNewRestaurantCommand>
    {
        public RegisterNewRestaurantCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateExpertise();
        }
    }
}
