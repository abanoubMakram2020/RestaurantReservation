using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int No { get; set; }
        //[Required]
        //public int Capicty { get; set; }
        public virtual List<Reservation> Reservation { get; set; }
    }
}
