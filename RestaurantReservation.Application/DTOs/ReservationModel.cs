using RestaurantReservation.Application.CustomValidation;
using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RestaurantReservation.Application.DTOs
{
    public class ReservationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ClientNameRequired", 
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        [MaxLength(50, ErrorMessage = "max 50 char")]
        [Display(Name ="ClientName",ResourceType = typeof(Resources.ReservationResources))]
        public string ClientName { get; set; }

        [Required(ErrorMessageResourceName = "TableNoRequired",
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        [Display(Name = "TableNo", ResourceType = typeof(Resources.ReservationResources))]
        public int TableNo { get; set; }
        public int TableNoId { get; set; }

        [Required(ErrorMessageResourceName = "NumberOfPeopleRequired",
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        [Display(Name = "NumberOfPeople", ResourceType = typeof(Resources.ReservationResources))]
        [MinValue(1, ErrorMessageResourceName = "Min1",
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        [MaxValue(10, ErrorMessageResourceName = "Max10",
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.ReservationResources))]
        public string Note { get; set; }


        [Required(ErrorMessageResourceName = "ReservationFoodsRequired",
            ErrorMessageResourceType = typeof(Resources.ReservationResources))]
        [Display(Name = "ReservationFoods", ResourceType = typeof(Resources.ReservationResources))]
        public List<string> FoodTypes { get; set; }
    }
}
