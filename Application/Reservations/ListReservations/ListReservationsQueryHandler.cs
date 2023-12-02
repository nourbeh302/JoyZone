using Domain.Reservations;
using MediatR;

namespace Application.Reservations.ListReservations;

public class ListReservationsQueryHandler : IRequestHandler<ListReservationsQuery, IReadOnlyList<ListReservationsResponse>>
{
    private readonly IReservationRepository _reservationRepository;

    public ListReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<IReadOnlyList<ListReservationsResponse>> Handle(ListReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.ListAsync();

        var response = reservations.Select(r => new ListReservationsResponse(
            r.Id,
            r.DurationInMinutes,
            r.CreatedAtUtc,
            r.Price,
            Enum.GetName(r.Status)!,
            r.CustomerId,
            r.RoomId,
            r.GameId));
        
        return new List<ListReservationsResponse>(response);
    }
}

