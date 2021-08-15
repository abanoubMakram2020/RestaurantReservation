using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Models
{
    public class Unit
    {
        public Unit()
        {
            FoodTypes = new HashSet<FoodType>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameAr { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameEn { get; set; }
        public ICollection<FoodType> FoodTypes { get; set; }
    }
}
