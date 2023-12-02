namespace Domain.Rooms;

public interface IRoomRepository
{
    Task<IReadOnlyList<Room>> ListAsync();
    Task<Room?> GetByIdAsync(Guid id);
    Task CreateAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(Guid id);
}

