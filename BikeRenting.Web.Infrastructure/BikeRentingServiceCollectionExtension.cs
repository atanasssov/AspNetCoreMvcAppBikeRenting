using BikeRenting.Services.Data;
using BikeRenting.Services.Data.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BikeRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IBikeService, BikeService>();


            return services;
        }
    }
}
