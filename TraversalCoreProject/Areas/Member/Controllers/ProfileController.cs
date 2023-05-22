﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Windows.Markup;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name= values.Name;
            userEditViewModel.surname= values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail= values.Email;
            return View(userEditViewModel);
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        //{
        //    return View();
        //}
    }
}
