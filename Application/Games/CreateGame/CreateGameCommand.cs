using Domain.Customers;
using Domain.Games;
using MediatR;

namespace Application.Games.CreateGame;

public class CreateGameCommand : IRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Genre Genre { get; set; }
    public short Rating { get; set; }
}
