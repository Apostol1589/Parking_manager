using Microsoft.EntityFrameworkCore;
using ParkingManager.BusinessLogic.Adapters;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.Decorator;
using ParkingManager.BusinessLogic.FactoryMethod.Factory;
using ParkingManager.BusinessLogic.FactoryMethod.FactoryService;
using ParkingManager.BusinessLogic.Services;
using ParkingManager.DataAccess.Data;
using ParkingManager.DataAccess.Repositories.ParkingLotRepo;
using ParkingManager.DataAccess.Repositories.ParkingSpaceRepo;
using ParkingManager.DataAccess.Repositories.ParkingTicketRepo;
using ParkingManager.DataAccess.Repositories.VehicleRepo;
using TaxCalculationSdk;


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
            builder.Services.AddScoped<ITaxCalculationAdapter, TaxCalculationAdapter>();
            builder.Services.AddScoped<ITaxCalculationSdk, TaxCalculationSdk.TaxCalculationSdk>();
            builder.Services.AddScoped<ParkingTicketFactory, HourlyTicketFactory>();
            builder.Services.AddScoped<ParkingTicketFactory, DailyTicketFactory>();
            builder.Services.AddScoped<IFactoryTicketService, FactoryTicketService>();
            //Decorators
            builder.Services.Decorate<IParkingTicketService, ParkingTicketLoggingDecorator>();
            //builder.Services.AddScoped<IParkingTicketService, ParkingTicketLoggingDecorator>();

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
