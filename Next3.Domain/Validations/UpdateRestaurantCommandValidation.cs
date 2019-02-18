using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class UpdateRestaurantCommandValidation : RestaurantValidation<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateExpertise();
            ValidateAddress();
        }
    }
}
