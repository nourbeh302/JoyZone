using Domain.Reservations;
using MediatR;

namespace Application.Reservations.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationRepository.CreateAsync(new()
        {
            Id = Guid.NewGuid(),
            DurationInMinutes = request.DurationInMinutes,
            Price = request.Price,
            CustomerId = request.CustomerId,
            RoomId = request.RoomId,
            GameId = request.GameId,
        });
    }
}