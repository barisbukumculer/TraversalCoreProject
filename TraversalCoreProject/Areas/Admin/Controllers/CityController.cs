using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var JsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(JsonCity);

        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);

        }
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);

            if (values == null)
            {
                return Json(null);
            }
            else
            {
                var jsonvalues = JsonConvert.SerializeObject(values);
                return Json(jsonvalues);
            }
        }
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }
        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var jsonvalues= JsonConvert.SerializeObject(destination);
            return Json(jsonvalues);
        }
        public static List<CityClass> cities = new List<CityClass>
        {
            new CityClass
            {
                CityID=1,
                CityCountry="Makedonya",
                CityName="Üsküp"
            },
            new CityClass
            {
                CityID=2,
                CityCountry="İtalya",
                CityName="Roma"
            },
            new CityClass
            {
                CityID=3,
                CityCountry="İngiltere",
                CityName="Londra"
            }
        };

    }
}
