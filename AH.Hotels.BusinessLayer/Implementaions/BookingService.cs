using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.BusinessLayer.Interfaces;
using AH.Hotels.BusinessLayer.Models;
using AH.Hotels.Entities;
using AH.Hotels.RepoLayer.Interfaces;
using AutoMapper;

namespace AH.Hotels.BusinessLayer.Implementaions
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IMapper _mapper;
        public BookingService(IBookingRepo bookingRepo, IMapper mapper)
        {
            _bookingRepo= bookingRepo;
            _mapper= mapper;
        }

        public async Task<BookingDetailModel> GetBookingDetails(int id)
        {
            var bookingDetails = await _bookingRepo.GetBookingDetail(id);
            var bookingResponse = _mapper.Map<BookingDetailModel>(bookingDetails);
            return bookingResponse;
        }

        public async Task<IEnumerable<HotelDetailModel>> GetHotels(string search)
        {
            var result = await _bookingRepo.GetHotels(search);
            var response = _mapper.Map<IEnumerable<HotelDetailModel>>(result);
            return response;
            //List<HotelDetailModel> hotels = new List<HotelDetailModel>();
            //hotels.Add(new HotelDetailModel { Id = 1, Address = "Add", City = "City", Country = "UAE", HotelName = "Radison", IsActive = true, Mobile = "54334534", Phone = "2342323423" });
            //return hotels;
            //await Task.CompletedTask;
        }

        public async Task<IEnumerable<BookingDetailModel>> GetBookingListByHotel(int hotelId)
        {
            var result = await _bookingRepo.GetBookingListByHotel(hotelId);
            var response = _mapper.Map<IEnumerable<BookingDetailModel>>(result);
            return response;
        }

        public async Task<HotelDetailModel> GetHotelDetails(int hotelId)
        {
            var result = await _bookingRepo.GetHotelDetail(hotelId);
            var response = _mapper.Map<HotelDetailModel>(result);
            return response;
        }

        public async Task<int> CreateBooking(BookingDetailModel bookingRequest)
        {
            var model = _mapper.Map<BookingDetail>(bookingRequest);
            var id = await _bookingRepo.CreateBooking(model);
            return id;
        }
    }
}
