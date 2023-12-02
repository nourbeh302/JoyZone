using MediatR;
using System.Diagnostics;

namespace Application.Reservations.CreateReservation;

public record CreateReservationCommand(
    short DurationInMinutes,
    short Price,
    Guid CustomerId,
    Guid RoomId,
    Guid GameId) : IRequest;
