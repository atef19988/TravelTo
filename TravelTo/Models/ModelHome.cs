using TravelTo.Domain.Models;

namespace TravelTo.Models
{
    public class ModelHome
    {
        public ModelHome()
        {
            Sliders = new List<TbSlider>();
            Tours = new List<TbTour>();
            UserModel = new RegisterModel();
        }
        public List<TbSlider> Sliders { get; set; } 
        public List<TbTour> Tours { get; set; }
        public RegisterModel UserModel { get; set; }
        public TbSettings Settings { get; set; }

    }
}
