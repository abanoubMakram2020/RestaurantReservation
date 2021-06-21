using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Models
{
    public class ReservationFoods
    {
        [Key]
        public int Id { get; set; }
        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public FoodType FoodType { get; set; }
        //public decimal FoodAmount { get; set; }
    }
}
