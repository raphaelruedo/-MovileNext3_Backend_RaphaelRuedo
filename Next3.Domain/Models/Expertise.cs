using Next3.Domain.Core.Models;

namespace Next3.Domain.Models
{
    public class Expertise : Entity
    {
        public Expertise(string name)
        {
            Name = name;
        }
        public Expertise() { }

        public string Name { get; set; }

        public Restaurant Restaurant;
    }
}
