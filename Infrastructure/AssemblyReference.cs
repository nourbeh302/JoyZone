using Application.Common.Abstractions;
using Domain.Customers;
using Domain.Games;
using Domain.Reservations;
using Domain.Rooms;
using Infrastructure.Authentication;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=JoyZone_Db;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True";

        services.AddScoped<DbContext, ApplicationDbContext>();
        
        services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
        services.AddScoped(typeof(IRoomRepository), typeof(RoomRepository));
        services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
        services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
        services.AddScoped(typeof(IJwtProvider), typeof(JwtProvider));

        // Authentication services go here!

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
