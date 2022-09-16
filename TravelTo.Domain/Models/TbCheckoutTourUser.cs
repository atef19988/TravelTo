using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class TbCheckoutTourUser : Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }

        [ValidateNever]
        public TbTour TbTour { get; set; }

        
    }
}
