using Domain.Reservations;
using MediatR;

namespace Application.Reservations.GetReservationById;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdResponse?>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationByIdQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<GetReservationByIdResponse?> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id);

        if (reservation == null)
            return null;

        return new GetReservationByIdResponse(reservation.DurationInMinutes,
            reservation.CreatedAtUtc,
            reservation.Price,
            Enum.GetName(reservation.Status)!,
            reservation.CustomerId,
            reservation.RoomId,
            reservation.GameId);
    }
}

