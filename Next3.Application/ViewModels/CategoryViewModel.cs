using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Next3.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid id { get; set; }

        public string Name { get; set; }
    }
}
