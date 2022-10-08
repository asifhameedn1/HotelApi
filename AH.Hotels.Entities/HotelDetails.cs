using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AH.Hotels.Entities
{
    public class HotelDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [Required]
        public int Id { get; set; }
        public string HotelName { get; set; } = "";
        public bool IsActive { get; set; }
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Phone { get; set; } = "";

        public virtual ICollection<RoomDetails> Rooms { get; set; }
        public virtual IEnumerable<BookingDetail> Bookings { get; set; }
    }
}