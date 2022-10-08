using AH.Hotels.BusinessLayer;
using AH.Hotels.BusinessLayer.Implementaions;
using AH.Hotels.BusinessLayer.Interfaces;

namespace AH.Hotels.Apis
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IBookingService, BookingService>();
            ServiceRegistration.RegisterServices(services, configuration);
            return services;
        }
    }
}
