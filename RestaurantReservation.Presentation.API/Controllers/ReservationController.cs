using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using SharedKernal.Core.Common;
using SharedKernal.Middlewares.Basees;
using System;
using System.Threading.Tasks;

namespace RestaurantReservation.Presentation.API.Controllers
{
    public class ReservationController : BaseController
    {
        #region Fields
        private readonly IReservationService _reservationService;
        #endregion

        #region ctor
        public ReservationController(IReservationService reservationService,Presenter presenter):base(presenter)
        {
            _reservationService = reservationService;
        }

        #endregion

        #region Actions
        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Index()
        {
            return await _Presenter.Handle(_reservationService.GetReservationByDate,new BaseRequestDto<DateTime> { 
            Data= DateTime.Now.Date
            });
        
        }
        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> CreateEdit(int? rservId)
        {
            ReservationModel model = new ReservationModel();

            _FillViewBags();
            if (rservId != null)
                return await _Presenter.Handle(_reservationService.FillReservationModel, new BaseRequestDto<int>
                {
                    Data = rservId.Value
                });

            return  Ok(model);
        }

        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> CreateEdit(ReservationModel reservationModel)
        {

            return await _Presenter.Handle(_reservationService.SaveReservation, new BaseRequestDto<ReservationModel>
                {Data= reservationModel});
        }
        [HttpDelete]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Delete(int rservId)
        {
          return await _Presenter.Handle(_reservationService.DeleteReservationById, new BaseRequestDto<int> {Data= rservId });
        }

      
        #endregion


        #region Helper Method
        protected void _FillViewBags()
        {
            //var listOftables = _tableService.GetTableNotReservedToday().
            //                    Select(t =>
            //                        new SelectListItem
            //                        {
            //                            Text = t.No + string.Empty,
            //                            Value = t.Id + string.Empty
            //                        });
            //ViewBag.TablesList = new SelectList(listOftables, "Value", "Text");

            //var foods = _foodTypeService.GetFoodTypeList().Select(f =>
            //                        new SelectListItem
            //                        {
            //                            Text = (CultureInfo.CurrentCulture.Name.ToLower().Contains("ar") ? f.FoodNameAr : f.FoodNameEn) + string.Empty,
            //                            Value = f.Id + string.Empty
            //                        });
            //ViewBag.FoodsList = new SelectList(foods, "Value", "Text");


        }

        #endregion
    }
}
