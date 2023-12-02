using Domain.Reservations;
using MediatR;

namespace Application.Reservations.CancelReservation;

public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public CancelReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationRepository.CancelAsync(request.Id);
    }
}