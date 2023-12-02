namespace Application.Reservations.GetReservationById;

public record GetReservationByIdResponse(
    short DurationInMinutes,
    DateTime CreatedAtUtc,
    short Price,
    string Status,
    Guid CustomerId,
    Guid RoomId,
    Guid GameId);

