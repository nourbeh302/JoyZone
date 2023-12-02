using Domain.Games;
using MediatR;

namespace Application.Games.ListGames;

public class ListGamesQueryHandler : IRequestHandler<ListGamesQuery, IReadOnlyList<ListGamesResponse>>
{
    private readonly IGameRepository _gameRepository;

    public ListGamesQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IReadOnlyList<ListGamesResponse>> Handle(ListGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.ListAsync();

        return games.Select(g => new ListGamesResponse(
            g.Id,
            g.Name,
            g.Description,
            g.AddedOnUtc,
            g.Genre,
            g.Rating)).ToList();
    }
}
