using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.Entities;
using AH.Hotels.RepoLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AH.Hotels.RepoLayer.Implementations
{
    public class BookingRepo : IBookingRepo
    {
        private readonly HotelContext _hotelContext;
        public BookingRepo(HotelContext feedContext)
        {
            _hotelContext = feedContext;
        }

        public async Task<int> CreateBooking(BookingDetail entity)
        {
            var res = await _hotelContext.BookingDetail
                .Where(x => ((x.BookedFrom >= entity.BookedFrom && x.BookedFrom <= entity.BookedTo) ||
                (x.BookedTo <= entity.BookedFrom && x.BookedTo >= entity.BookedTo) ||
                (x.BookedFrom <= entity.BookedFrom && x.BookedTo >= entity.BookedTo)) && x.RoomId == entity.RoomId && x.HotelId== entity.HotelId)
                .ToListAsync();
            if (!res.Any())
            {
                var room = await _hotelContext.RoomDetail.Where(x => x.Id == entity.RoomId).FirstOrDefaultAsync();
                if (room != null)
                {


                    entity.Rate = room.Rate;
                    entity.BookedAmount = room.Rate - (room.Rate * entity.DiscountPercent);

                    await _hotelContext.AddAsync(entity);
                    await _hotelContext.SaveChangesAsync();
                }
                return entity.Id;
            }
            return 0;
        }

        public async Task<BookingDetail> GetBookingDetail(int id)
        {
            return await _hotelContext.BookingDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingListByHotel(int hotelId)
        {
            return await _hotelContext.BookingDetail.Where(x => x.HotelId == hotelId).ToListAsync();
        }

        public async Task<HotelDetails> GetHotelDetail(int id)
        {
            return await _hotelContext.HotelDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HotelDetails>> GetHotels(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return await _hotelContext.HotelDetail.Where(x => x.HotelName.Contains(search)).ToListAsync();
            }
            else
            {
                return await _hotelContext.HotelDetail.ToListAsync();
            }
        }

    }
}