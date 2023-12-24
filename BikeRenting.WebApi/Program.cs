using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Web.Infrastructure.Extensions;

namespace BikeRenting.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<BikeRentingDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("BikeRenting", policyBuilder =>
                {
                    policyBuilder
                        .WithOrigins("https://localhost:7279")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("BikeRenting");

            app.Run();
        }
    }
}