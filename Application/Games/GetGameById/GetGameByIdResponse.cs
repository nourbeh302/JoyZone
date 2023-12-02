using Domain.Games;

namespace Application.Games.GetGameById;

public record GetGameByIdResponse(
    string Name,
    string Description,
    Genre Genre,
    DateTime AddedOnUtc,
    short Rating);
