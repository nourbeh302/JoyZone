using Domain.Rooms;
using MediatR;

namespace Application.Rooms.DeleteRoom;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        await _roomRepository.DeleteAsync(request.Id);
    }
}
