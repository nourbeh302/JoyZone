using Domain.Customers;
using Domain.Games;
using Domain.Rooms;

namespace Domain.Reservations;

public class Reservation
{
    public Guid Id { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public short DurationInMinutes { get; set; }
    public short Price { get; set; }
    public Status Status { get; set; } = Status.Pending;

    public Guid CustomerId { get; set; }
    public Guid RoomId { get; set; }
    public Guid GameId { get; set; }

    public Customer? Customer { get; set; }
    public Room? Room { get; set; }
    public Game? Game { get; set; }
}