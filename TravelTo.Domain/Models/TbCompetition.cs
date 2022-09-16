using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class TbCompetition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
   
        [ValidateNever]       
        public string ImageName { get; set; }
      
        [ValidateNever]
        public List<TbCompetitionUser> TbCompetitionUsers { get; set; }

        public TbCompetition()
        {

            TbCompetitionUsers = new List<TbCompetitionUser>();

        }


    }
}
