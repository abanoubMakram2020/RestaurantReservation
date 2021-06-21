using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace RestaurantReservation.Presentation.MVC.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        #region Fields
        private const string CONTROLLER_NAME = "Reservation";
        private const string VIEW_MAIN_PATH = "~/Views/";

        private readonly IUnitService _unitService;
        private readonly IFoodTypeService _foodTypeService;
        private readonly IReservationService _reservationService;
        private readonly ITableService _tableService;
        private readonly IReservationFoodsService _reservationFoodseService;
        #endregion

        #region ctor
        public ReservationController(IUnitService unitService,
                             IFoodTypeService foodTypeService,
                             ITableService tableService,
                             IReservationService reservationService,
                             IReservationFoodsService reservationFoodseService)
        {
            _unitService = unitService;
            _foodTypeService = foodTypeService;
            _tableService = tableService;
            _reservationFoodseService = reservationFoodseService;
            _reservationService = reservationService;
        }

        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View(_reservationService.GetReservationByDate(DateTime.Now.Date));
        }

        public IActionResult CreateEdit(int? rservId)
        {
            ReservationModel model = new ReservationModel();

            _FillViewBags();
            if (rservId != null)
                model = _reservationService.FillReservationModel(rservId.Value);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(ReservationModel reservationModel)
        {

            await _reservationService.SaveReservation(reservationModel);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int rservId)
        {
            _reservationService.DeleteReservationById(rservId);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public JsonResult GetReservationFoods([FromBody] AjaxDTO ajaxDTO)
        //{

        //    return Json(_reservationFoodseService.GetReservationFoodsByReservationId(ajaxDTO.reservId));

        //}
        #endregion


        #region Helper Method
        protected void _FillViewBags()
        {
            var listOftables = _tableService.GetTableNotReservedToday().
                                Select(t =>
                                    new SelectListItem
                                    {
                                        Text = t.No + string.Empty,
                                        Value = t.Id + string.Empty
                                    });
            ViewBag.TablesList = new SelectList(listOftables, "Value", "Text");

            var foods = _foodTypeService.GetFoodTypeList().Select(f =>
                                    new SelectListItem
                                    {
                                        Text = (CultureInfo.CurrentCulture.Name.ToLower().Contains("ar") ? f.FoodNameAr : f.FoodNameEn) + string.Empty,
                                        Value = f.Id + string.Empty
                                    });
            ViewBag.FoodsList = new SelectList(foods, "Value", "Text");


        }

        #endregion
    }
}
