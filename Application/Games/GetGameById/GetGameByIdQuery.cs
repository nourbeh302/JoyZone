using MediatR;

namespace Application.Games.GetGameById;

public record GetGameByIdQuery(Guid Id) : IRequest<GetGameByIdResponse>;
