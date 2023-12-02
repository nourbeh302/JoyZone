namespace Domain.Games;

public interface IGameRepository
{
    Task<IReadOnlyList<Game>> ListAsync();
    Task<Game?> GetByIdAsync(Guid id);
    Task CreateAsync(Game game);
}