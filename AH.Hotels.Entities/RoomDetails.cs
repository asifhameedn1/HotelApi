using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Hotels.Entities
{
    public class RoomDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [Required]
        public int Id { get; set; }

        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int RoomType { get; set; }
        public bool IsActive { get; set; }
        public decimal Rate { get; set; }
        public virtual HotelDetails Hotels { get; set; }
        public virtual ICollection<BookingDetail> Bookings { get; set; }
    }
}
