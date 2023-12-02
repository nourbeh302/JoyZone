using Domain.Games;
using MediatR;

namespace Application.Games.GetGameById;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GetGameByIdResponse?>
{
    private readonly IGameRepository _gameRepository;

    public GetGameByIdQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GetGameByIdResponse?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        Game? game = await _gameRepository.GetByIdAsync(request.Id);
        
        if (game == null)
            return null;

        return new GetGameByIdResponse(
            game.Name,
            game.Description,
            game.Genre,
            game.AddedOnUtc,
            game.Rating);
    }
}
