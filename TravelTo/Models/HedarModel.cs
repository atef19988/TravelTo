using TravelTo.Domain.Models;

namespace TravelTo.Models
{
    public class HedarModel
    {
        public TbSettings TbSettings { get; set; }
        public RegisterModel UserModel { get; set; }

        public HedarModel( )
        {
            UserModel = new RegisterModel() ;
            TbSettings = new TbSettings();
        }
    }
}
