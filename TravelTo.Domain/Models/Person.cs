using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class Person
    {

 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string jop { get; set; }
        [Required] 
        public int Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }
}
