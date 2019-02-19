using Next3.Domain.Commands;

namespace Next3.Domain.Validations
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidateAddress();
            ValidateItems();
            ValidateStatus();
            ValidateUserId();
        }

    }
}
