using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult >MyActiveReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByAccepted(values.Id);
            return View(valueslist);
        }
        public async Task< IActionResult> MyOldReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(valueslist);
        }
        public async Task< IActionResult> MyApprovalReservations()
        {
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
          var valueslist=  reservationManager.GetListWithReservationByWaitApproval(values.Id);
            return View(valueslist);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text= x.City,
                                               Value= x.DestinationID.ToString()    
                                           }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.Status = "Onay Bekliyor";
            reservation.AppUserID = 5;
            reservationManager.TAdd(reservation);
            return RedirectToAction("MyActiveReservations");
        }
    }
}
