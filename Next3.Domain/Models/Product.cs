using Next3.Domain.Core.Models;

namespace Next3.Domain.Models
{
    public class Product : Entity
    {
        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public Product() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
