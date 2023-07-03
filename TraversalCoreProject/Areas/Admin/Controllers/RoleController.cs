using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        [Route("NewRole")]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        [Route("NewRole")]
        public async Task< IActionResult> NewRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole role = new AppRole()
            {
                Name = createRoleViewModel.RoleName
            };
            var result=await _roleManager.CreateAsync(role);
            if(result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Route("DeleteRole/{id}")]
        public async Task< IActionResult> DeleteRole(int id)
        {
            var values=_roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel
            {
                RoleID = values.Id,
                RoleName = values.Name
            };
            return View(updateRoleViewModel);
        }
        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
            values.Name=updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
    }
}
