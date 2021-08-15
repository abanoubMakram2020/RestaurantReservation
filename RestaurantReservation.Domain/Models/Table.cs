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
        public Table()
        {
            Reservation = new HashSet<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int No { get; set; }
        //[Required]
        //public int Capicty { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
