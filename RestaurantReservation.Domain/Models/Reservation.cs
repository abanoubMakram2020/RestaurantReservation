using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [Required]
        public int TableNo { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }


        public string Note { get; set; }


        [ForeignKey("TableNo")]
        public virtual Table Table { get; set; }

        public virtual ICollection<ReservationFoods> ReservationFoods { get; set; }
    }
}
