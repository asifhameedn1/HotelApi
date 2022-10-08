using AH.Hotels.BusinessLayer.Interfaces;
using AH.Hotels.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AH.Hotels.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetHotels")]
        public async Task<IActionResult> Get(string? search)
        {
            var hotelList = await _bookingService.GetHotels(search);
            if (hotelList.Any())
            {
                return Ok(hotelList);
            }
            else
            {
                return BadRequest("No Data");
            }
        }

        [HttpGet("HotelDetails/{hotelId:int}")]
        public async Task<IActionResult> HotelDetails(int hotelId)
        {
            return Ok(await _bookingService.GetHotelDetails(hotelId));
        }

        [HttpGet("{bookingId:int}")]
        public async Task<IActionResult> BookingDetails(int bookingId)
        {
            return Ok(await _bookingService.GetBookingDetails(bookingId));
        }

        [HttpPost("CreateReservation")]
        public async Task<IActionResult> Create([FromBody] BookingDetailModel request)
        {   
            return Ok(await _bookingService.CreateBooking(request));
        }
    }
}
