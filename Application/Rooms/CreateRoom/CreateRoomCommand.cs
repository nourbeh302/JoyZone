using MediatR;

namespace Application.Rooms.CreateRoom;

public record CreateRoomCommand(string Name) : IRequest;