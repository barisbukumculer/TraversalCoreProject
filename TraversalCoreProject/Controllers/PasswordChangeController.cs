using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser>  _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);
            string passwordResetToken=await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                UserId = user.Id,
                token=passwordResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "barisbukumculer@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değiştirme Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("barisbukumculer@gmail.com", "zqmwcvqpyzhcwjga");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
		}
		[HttpGet]
		public IActionResult ResetPassword(string userid,string token)
		{
            TempData["userid"] = userid;
            TempData["token"] = token;
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
            var userid = TempData["userid"];
            var token= TempData["token"];
            if (userid==null || token==null)
            {
                //hata mesajları
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result= await _userManager.ResetPasswordAsync(user,token.ToString(),model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
			return View();
		}
	}
}
