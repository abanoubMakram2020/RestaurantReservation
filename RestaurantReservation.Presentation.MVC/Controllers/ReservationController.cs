using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using SharedKernal.Middlewares.Basees;

namespace RestaurantReservation.Presentation.MVC.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        #region Fields
        public Presenter Presenter { get; set; }
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
            Presenter = new Presenter();
        }

        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            var reservationlst= await _reservationService.GetReservationByDate( new BaseRequestDto<DateTime>
            {
                Data = DateTime.Now.Date
            });
            return View(reservationlst.Result);
        }

        public async Task<IActionResult> CreateEdit(int? rservId)
        {
            ReservationModel model = new ReservationModel();

            _FillViewBags();
            if (rservId != null)
            {
               var obj  = await _reservationService.FillReservationModel(new BaseRequestDto<int>
                {
                    Data = rservId.Value
                });
                model = obj.Result;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(ReservationModel reservationModel)
        {
           await _reservationService.SaveReservation( new BaseRequestDto<ReservationModel>
            { Data = reservationModel });

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int rservId)
        {
            await _reservationService.DeleteReservationById( new BaseRequestDto<int> { Data = rservId });
            return RedirectToAction(nameof(Index));
        }

     
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
