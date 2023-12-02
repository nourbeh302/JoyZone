using Domain.Games;

namespace Application.Games.ListGames;

public record ListGamesResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime AddedOnUtc,
    Genre Genre,
    short Rating);
