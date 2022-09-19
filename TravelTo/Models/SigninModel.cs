using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class SigninModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
       

      

    }
}
