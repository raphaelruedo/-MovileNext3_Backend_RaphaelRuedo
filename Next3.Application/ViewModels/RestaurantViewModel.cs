using System;
using System.ComponentModel.DataAnnotations;

namespace Next3.Application.ViewModels
{
    public class RestaurantViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid ExpertiseId { get; set; }
    }
}
