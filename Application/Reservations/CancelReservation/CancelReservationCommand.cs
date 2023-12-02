using MediatR;

namespace Application.Reservations.CancelReservation;

public record CancelReservationCommand(Guid Id) : IRequest;
