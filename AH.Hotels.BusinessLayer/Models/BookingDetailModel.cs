using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Hotels.BusinessLayer.Models
{
    public class BookingDetailModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; } = "";
        public int NoOfRooms { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; } = "";
        public decimal Rate { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal BookedAmount { get; set; }

    }
}
