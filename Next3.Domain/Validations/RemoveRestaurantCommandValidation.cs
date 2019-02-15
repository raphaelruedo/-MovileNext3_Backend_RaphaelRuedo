using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class RemoveRestaurantCommandValidation : RestaurantValidation<RemoveRestaurantCommand>
    {
        public RemoveRestaurantCommandValidation()
        {
            ValidateId();
        }
    }
}
