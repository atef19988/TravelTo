using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Components
{
    public class FotterViewComponent : ViewComponent
    {
        IRepository<TbSettings> _repSetings;

        public FotterViewComponent(IRepository<TbSettings> repSetings)
        {
            _repSetings = repSetings;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View((await _repSetings.GetAll()).FirstOrDefault());
        }
    }
}
