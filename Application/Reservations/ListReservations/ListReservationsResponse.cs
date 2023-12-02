using Domain.Reservations;

namespace Application.Reservations.ListReservations;

public record ListReservationsResponse(
    Guid Id,
    short DurationInMinutes,
    DateTime CreatedAtUtc,
    short Price,
    string Status,
    Guid CustomerId,
    Guid RoomId,
    Guid GameId);

