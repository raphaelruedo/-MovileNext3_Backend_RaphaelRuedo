using Next3.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Next3.Domain.Models
{
    public class OrderStatus : Entity
    {
        public OrderStatus(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        protected OrderStatus() { }

        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
