using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _ProfileInformation:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<  IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = values.Name + " " + values.Surname;
            ViewBag.phone = values.PhoneNumber;
            ViewBag.mail = values.Email;
            return View();
        }
    }
}
