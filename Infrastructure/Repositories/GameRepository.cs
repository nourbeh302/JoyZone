using Domain.Games;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _context;

    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Game>> ListAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        var room = await _context.Games.FirstOrDefaultAsync(c => c.Id == id);

        if (room is null)
            return null;

        return room;
    }

    public async Task CreateAsync(Game room)
    {
        await _context.Games
            .AddAsync(room);

        _context.SaveChanges();
    }
}


