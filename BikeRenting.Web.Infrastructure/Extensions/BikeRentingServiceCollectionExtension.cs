using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using BikeRenting.Services.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BikeRenting.Web.Infrastructure.Extensions
{
    public static class BikeRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

