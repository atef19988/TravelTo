using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;
using TravelTo.Ef;
using TravelTo.Models;

namespace TravelTo.Components
{
    public class HederViewComponent : ViewComponent
    {
        IRepository<TbSettings> _repSetings;
        IRepository<AppUserIdentity> _AppUserIdentity;

        HedarModel _hedarModel;
        SignInManager<AppUserIdentity> _signInManager;
        public HederViewComponent(IRepository<TbSettings> repSetings, IRepository<AppUserIdentity> AppUserIdentity, SignInManager<AppUserIdentity> signInManager)
        {
            _hedarModel = new HedarModel();
            _repSetings = repSetings;
            _signInManager = signInManager;
            _AppUserIdentity=AppUserIdentity;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
              
            _hedarModel.TbSettings= (await _repSetings.GetAll()).FirstOrDefault();
            string id= _signInManager.UserManager.GetUserId(HttpContext.User);
            if (id!=null)
            {
                var user = await _AppUserIdentity.GetByCriteria(a => a.Id == id);
                _hedarModel.UserModel.FirstName = user.FirstName;
                _hedarModel.UserModel.LastName = user.LastName;
                _hedarModel.UserModel.Email = user.Email;
                _hedarModel.UserModel.ImageName = user.ImageName;
            }
           

            return View(_hedarModel);
        }
    }
}
