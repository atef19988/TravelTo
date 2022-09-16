using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Domain.Models
{
    public class TbCompetitionUser:Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CompetitionId { get; set; }
        [ValidateNever]
        public TbCompetition TbCompetition { get; set; }
     


    }
}
