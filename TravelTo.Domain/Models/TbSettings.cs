using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class TbSettings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public string ImageName { get; set; }
        [ValidateNever]
        public string Logo { get; set; }
        [Required]
        public string Loction { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        public string FaceBookUrl { get; set; } 
        public string YouTubeUrl { get; set; }

    }
}
