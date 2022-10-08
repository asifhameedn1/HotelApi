using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.Entities;

namespace AH.Hotels.RepoLayer.Interfaces
{
    public interface IBookingRepo
    {
        Task<IEnumerable<HotelDetails>> GetHotels(string search);
        Task<BookingDetail> GetBookingDetail(int id);
        Task<IEnumerable<BookingDetail>> GetBookingListByHotel(int hotelId);
        Task<HotelDetails> GetHotelDetail(int id);
        Task<int> CreateBooking(BookingDetail entity);
    }
}
