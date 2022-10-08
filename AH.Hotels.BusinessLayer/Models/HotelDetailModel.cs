using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Hotels.BusinessLayer.Models
{
    public class HotelDetailModel
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = "";
        public bool IsActive { get; set; }
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Phone { get; set; } = "";

    }
}
