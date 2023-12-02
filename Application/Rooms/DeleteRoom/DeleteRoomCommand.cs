using MediatR;

namespace Application.Rooms.DeleteRoom;

public record DeleteRoomCommand(Guid Id) : IRequest;
