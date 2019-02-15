using Next3.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Next3.Domain.Models
{
    public class Restaurant : Entity
    {
        public Restaurant(Guid id, string name, string description, bool isActive, Guid expertiseId)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            ExpertiseId = expertiseId;
        }

        protected Restaurant() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public Guid ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }

        public List<Product> Products { get; set; }
    }
}
