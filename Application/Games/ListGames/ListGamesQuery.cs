using MediatR;

namespace Application.Games.ListGames;

public class ListGamesQuery : IRequest<IReadOnlyList<ListGamesResponse>> { }
