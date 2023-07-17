using Microsoft.Extensions.DependencyInjection;

using BikeRenting.Services.Data;
using BikeRenting.Services.Data.Interfaces;

namespace BikeRenting.Web.Infrastructure.Extensions
{
    public static class BikeRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IAgentService, AgentService>();

            return services;
        }
    }
}
