using System;
using System.ComponentModel.DataAnnotations;

namespace Next3.Application.ViewModels
{
    public class OrderStatusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
