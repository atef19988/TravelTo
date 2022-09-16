using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNatCore.Mvc.ModelBinding.validation;

namespace TravelTo.Domain.Models
{
    public class TbTour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TourName { get; set; }
        [Required]
        public string TourDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Discount { get; set; }   

        [ValidateNever]
        public string ImageName { get; set; }

        [ValidateNever]
        public List<TbCheckoutTourUser> TbCheckoutTourUsers { get; set; }

        public TbTour( )
        {
            TbCheckoutTourUsers = new List<TbCheckoutTourUser>();
        }
    }
}
