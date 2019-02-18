using Next3.Domain.Core.Commands;
using System;

namespace Next3.Domain.Commands
{
    public abstract class RestaurantCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool IsActive { get; protected set; }

        public Guid ExpertiseId { get; set; }

        public Guid AddressId { get; set; }

    }
}
