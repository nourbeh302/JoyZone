using MediatR;

namespace Application.Reservations.ListReservations;

public class ListReservationsQuery : IRequest<IReadOnlyList<ListReservationsResponse>> { }

