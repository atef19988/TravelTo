using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class TbLocationTour
    {
        [Key] 
        public int Id { get; set; }
        [ValidateNever]
        public string ImageName { get; set; }
        [Required] 
        public string NameLocation  { get; set; }  


    }
}
