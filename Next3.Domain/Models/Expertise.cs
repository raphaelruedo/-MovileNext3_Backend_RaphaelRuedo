using Next3.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Next3.Domain.Models
{
    public class Expertise : Entity
    {
        public Expertise(string name)
        {
            Name = name;
        }
        protected Expertise() { }

        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}
