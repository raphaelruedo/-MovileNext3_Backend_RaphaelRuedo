using Next3.Application.ViewModels;
using System.Collections.Generic;

namespace Next3.Application.EventSourcerNormalizers
{
    public class OrderHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Observation { get; set; }
        public List<OrderItemViewModel> OrderItens { get; set; }
        public AddressViewModel Address { get; set; }
        public string OrderStatusId { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
