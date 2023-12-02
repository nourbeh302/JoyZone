namespace Domain.Games;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Genre Genre { get; set; }
    public DateTime AddedOnUtc { get; set; } = DateTime.UtcNow;
    public short Rating { get; set; }
}
