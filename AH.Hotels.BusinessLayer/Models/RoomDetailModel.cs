using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Hotels.BusinessLayer.Models
{
    public class RoomDetailModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public bool IsActive { get; set; }
        public decimal Rate { get; set; }
    }
}
