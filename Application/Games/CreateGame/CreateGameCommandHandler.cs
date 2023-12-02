using Domain.Customers;
using Domain.Games;
using MediatR;

namespace Application.Games.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        await _gameRepository.CreateAsync(new()
        {
            Name = request.Name,
            Description = request.Description,
            Genre = request.Genre,
            Rating = request.Rating
        });
    }
}