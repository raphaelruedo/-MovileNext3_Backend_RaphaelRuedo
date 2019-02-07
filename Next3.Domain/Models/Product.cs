using Next3.Domain.Core.Models;
using System;

namespace Next3.Domain.Models
{
    public class Product : Entity
    {
        public Product(string name, string description, decimal price, Restaurant restaurant)
        {
            Name = name;
            Description = description;
            Price = price;
            Restaurant = restaurant;
        }

        public Product() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
