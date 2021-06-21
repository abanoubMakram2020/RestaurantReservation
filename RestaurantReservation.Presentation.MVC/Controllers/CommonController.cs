using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Application.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace RestaurantReservation.Presentation.MVC.Controllers
{
    public class DTO
    {
        public string key { get; set; }
    }

    [Route("/[controller]/[action]")]
    public class CommonController : Controller
    {
        [HttpPost]
        public JsonResult ReadFromResources([FromBody] DTO dto)
        {
            ResourceSet resourceSet = ReservationResources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture,
                true, true);

            return Json(resourceSet.GetString(dto.key));
        }
    }
}
