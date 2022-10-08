using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Hotels.Entities
{
    public class BookingDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [Required]
        public int Id { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public DateTime BookedFrom { get; set; }
        [Required]
        public DateTime BookedTo { get; set; }
        [Required] 
        public string BookedBy { get; set; }
        [Required] 
        public DateTime BookedOn { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public decimal DiscountPercent { get; set; }
        [Required]
        public decimal BookedAmount { get; set; }

        public virtual HotelDetails Hotel { get; set; }
        public virtual RoomDetails Room{ get; set; }
    }
}
