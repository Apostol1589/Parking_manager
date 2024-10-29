using Microsoft.EntityFrameworkCore;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.Services;
using ParkingManager.DataAccess.Data;
using ParkingManager.DataAccess.Repositories.ParkingLotRepo;
using ParkingManager.DataAccess.Repositories.ParkingSpaceRepo;
using ParkingManager.DataAccess.Repositories.ParkingTicketRepo;
using ParkingManager.DataAccess.Repositories.VehicleRepo;


namespace ParkingManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            // Add services to the container.
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IParkingLotRepository, ParkingLotRepository>();
            builder.Services.AddScoped<IParkingLotService, ParkingLotService>();
            builder.Services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            builder.Services.AddScoped<IParkingSpaceService, ParkingSpaceService>();
            builder.Services.AddScoped<IParkingTicketRepository, ParkingTicketRepository>();
            builder.Services.AddScoped<IParkingTicketService, ParkingTicketService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            app.Run();

            
        }
    }
}
