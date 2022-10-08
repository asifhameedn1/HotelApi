using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.BusinessLayer.Models;
using AH.Hotels.Entities;
using AutoMapper;

namespace AH.Hotels.BusinessLayer.Mapping
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string[] splitpath = path.Split("bin");
            var newpath = splitpath[0];

            CreateMap<HotelDetails, HotelDetailModel>();

            CreateMap<RoomDetails, RoomDetailModel>();

            CreateMap<BookingDetail, BookingDetailModel>();
            
            CreateMap<BookingDetailModel, BookingDetail>();
        }
    }
}
