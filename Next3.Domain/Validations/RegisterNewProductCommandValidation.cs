using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();
            ValidateCategory();
            ValidatePrice();
            ValidateRestaurant();
        }
    }
}
