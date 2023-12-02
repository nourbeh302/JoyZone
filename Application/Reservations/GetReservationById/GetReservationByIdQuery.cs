using Application.Reservations.ListReservations;
using MediatR;

namespace Application.Reservations.GetReservationById;

public record GetReservationByIdQuery(Guid Id) : IRequest<GetReservationByIdResponse?> { }

