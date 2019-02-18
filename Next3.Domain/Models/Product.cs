using Next3.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Next3.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id,string name, string description, decimal price, Guid restaurantId, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            RestaurantId = restaurantId;
            CategoryId = categoryId;
        }

        protected Product() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
