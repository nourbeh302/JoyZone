using MediatR;

namespace Application.Rooms.GetRoomById;

public record GetRoomByIdQuery(Guid Id) : IRequest<GetRoomByIdResponse?>;
