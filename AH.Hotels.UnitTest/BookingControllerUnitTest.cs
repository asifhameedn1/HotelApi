using AH.Hotels.Apis.Controllers;
using AH.Hotels.BusinessLayer.Interfaces;
using AH.Hotels.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AH.Hotels.UnitTest
{
    public class BookingControllerUnitTest
    {
        private readonly BookingController _bookingController;
        private readonly Mock<IBookingService> _bookService;
        private IEnumerable<HotelDetailModel> _hotelList;
        public BookingControllerUnitTest()
        {
            _bookService = new Mock<IBookingService>();
            _bookingController = new BookingController(_bookService.Object);
            _hotelList = new List<HotelDetailModel>() { Mock.Of<HotelDetailModel>(), Mock.Of<HotelDetailModel>() };

        }

        [Fact]
        public async void GetHotels_Success()
        {
            _bookService.Setup(x => x.GetHotels(It.IsAny<string>())).ReturnsAsync(_hotelList);
            var result = await _bookingController.Get(It.IsAny<string>());
            
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(2, ((IList<HotelDetailModel>)(((ObjectResult)result).Value)).Count);
        }

        [Fact]
        public async void GetHotels_Fail()
        {
            _hotelList = new List<HotelDetailModel>();
            _bookService.Setup(x => x.GetHotels(It.IsAny<string>())).ReturnsAsync(_hotelList);
            var result = await _bookingController.Get(It.IsAny<string>());

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            //Assert.Equal(2, ((IList<HotelDetailModel>)(((ObjectResult)result).Value)).Count);
        }
    }
}