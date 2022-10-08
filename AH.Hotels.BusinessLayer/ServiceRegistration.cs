using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.Entities;
using AH.Hotels.RepoLayer;
using AH.Hotels.RepoLayer.Implementations;
using AH.Hotels.RepoLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Hotels.BusinessLayer
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IBookingRepo, BookingRepo>();
            services.AddSingleton(_ => new HotelContext(config));

            return services;
        }
    }
}
