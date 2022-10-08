using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.BusinessLayer.Models;

namespace AH.Hotels.BusinessLayer.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<HotelDetailModel>> GetHotels(string search);
        Task<HotelDetailModel> GetHotelDetails(int hotelId);
        Task<BookingDetailModel> GetBookingDetails(int id);
        Task<IEnumerable<BookingDetailModel>> GetBookingListByHotel(int id);
        Task<int> CreateBooking(BookingDetailModel bookingRequest); 
    }
}
