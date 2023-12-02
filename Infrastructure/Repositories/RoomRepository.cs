using Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Room>> ListAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(c => c.Id == id);

        if (room is null)
            return null;

        return room;
    }

    public async Task CreateAsync(Room room)
    {
        await _context.Rooms
            .AddAsync(room);

        _context.SaveChanges();
    }

    public async Task UpdateAsync(Room room)
    {
        await _context.Rooms
            .Where(c => c.Id == room.Id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(c => c.Name, room.Name));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Rooms
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}