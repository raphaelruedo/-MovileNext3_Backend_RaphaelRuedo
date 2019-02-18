using Next3.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Next3.Domain.Models
{
    public class Order : Entity
    {
        public Order(Guid id, Guid userId, Address address, List<OrderItem> items, string observation, OrderStatus orderStatus)
        {
            Id = id;
            UserId = userId;
            Address = address;
            OrderItens = items;
            Observation = observation;
            OrderStatus = orderStatus;
        }

        protected Order() { }

        public string Observation { get; set; }
        public List<OrderItem> OrderItens { get; set; }

        public Guid UserId { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
