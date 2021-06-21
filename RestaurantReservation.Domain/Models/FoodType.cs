using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Models
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FoodNameAr { get; set; }

        [Required]
        [MaxLength(50)]
        public string FoodNameEn { get; set; }

        [Required]
        public int FoodSellUnit { get; set; }

        [ForeignKey("FoodSellUnit")]
        public virtual Unit Unit { get; set; }

        public virtual ICollection<ReservationFoods> ReservationFoods { get; set; }
    }
}
