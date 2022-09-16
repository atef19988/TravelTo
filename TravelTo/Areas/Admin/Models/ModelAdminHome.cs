using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Models
{
    public class ModelAdminHome
    {
        public ModelAdminHome()
        {
            TbTours = new List<TbTour>();
            TbCheckoutTourUser = new List<TbCheckoutTourUser>();

        }
        public List<TbTour> TbTours { get; set; } 
        public List<TbCheckoutTourUser> TbCheckoutTourUser { get; set; }
    }
}
