using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Models
{
    public class UserViewModel
    {
        [Display(Name = "Возраст")]
        [Range(10, 90)]
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
