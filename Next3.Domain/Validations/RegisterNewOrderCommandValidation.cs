using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidateAddress();
            ValidateItems();
            ValidateStatus();
            ValidateUserId();
        }
    }
}
