using Domain.Customers;
using Domain.Games;
using Domain.Reservations;
using Domain.Rooms;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder
            .ApplyConfiguration(new CustomerConfiguration())
            .ApplyConfiguration(new RoomConfiguration())
            .ApplyConfiguration(new ReservationConfiguration())
            .ApplyConfiguration(new GameConfiguration());
    }
}
