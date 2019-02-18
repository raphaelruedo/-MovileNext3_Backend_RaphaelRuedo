using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateCategory();
            ValidateRestaurant();
        }

    }
}
