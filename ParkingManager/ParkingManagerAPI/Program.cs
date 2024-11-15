using Microsoft.EntityFrameworkCore;
using ParkingManager.Domain.Contracts;
using ParkingManager.Application.Services;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Repositories.ParkingLotRepo;
using ParkingManager.Infrastructure.Repositories.ParkingSpaceRepo;
using ParkingManager.Infrastructure.Repositories.ParkingTicketRepo;
using ParkingManager.Infrastructure.Repositories.VehicleRepo;
using ParkingManager.Application.Mediator;
using ParkingManager.Application.CQRS.Core;
using ParkingManager.Application.CQRS.VehicleCQRS.Commands.Create;
using ParkingManager.Application.CQRS.VehicleCQRS.Commands.Delete;
using ParkingManager.Application.CQRS.VehicleCQRS.Commands.Update;
using ParkingManager.Application.CQRS.VehicleCQRS.Queries.Get;
using ParkingManager.Application.CQRS.VehicleCQRS.Queries.GetAll;
using ParkingManager.Domain.Entities;


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

            builder.Services.AddSingleton<IMediator, Mediator>();

            builder.Services.AddTransient<ICommandHandler<CreateVehicleCommand, int>, CreateVehicleCommandHandler>();
            builder.Services.AddTransient<ICommandHandler<DeleteVehicleCommand>, DeleteVehicleCommandHandler>();
            builder.Services.AddTransient<ICommandHandler<UpdateVehicleCommand>, UpdateVehicleCommandHandler>();
            builder.Services.AddTransient<IQueryHandler<GetVehicleByIdQuery, Vehicle?>, GetVehicleByIdQueryHandler>();
            builder.Services.AddTransient<IQueryHandler<GetAllVehiclesQuery, IReadOnlyCollection<Vehicle>>, GetAllVehiclesQueryHandler>();

            //builder.Services.AddMediatR(configuration =>
            //{
            //    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
            //});

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
