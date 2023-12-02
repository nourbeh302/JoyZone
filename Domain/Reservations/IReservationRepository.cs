namespace Domain.Reservations;

public interface IReservationRepository
{
    Task<IReadOnlyList<Reservation>> ListAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task CreateAsync(Reservation reservation);
    Task CancelAsync(Guid id);
    Task CompleteAsync(Guid id);
}
