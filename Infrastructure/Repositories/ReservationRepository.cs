using Domain.Customers;
using Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Reservation>> ListAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(c => c.Id == id);

        if (reservation is null)
            return null;

        return reservation;
    }

    public async Task CreateAsync(Reservation reservation)
    {
        await _context.Reservations
            .AddAsync(reservation);

        _context.SaveChanges();
    }

    public async Task CancelAsync(Guid id)
    {
        await _context.Reservations
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(r => r.Status, Status.Cancelled));
    }

    public Task CompleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
