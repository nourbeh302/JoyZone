using Domain.Rooms;
using MediatR;

namespace Application.Rooms.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand>
{
    private readonly IRoomRepository _roomRepository;

    public CreateRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room(Guid.NewGuid(), request.Name);
        
        await _roomRepository.CreateAsync(room);
    }
}

