using Domain.Rooms;
using MediatR;

namespace Application.Rooms.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, GetRoomByIdResponse?>
{

    public readonly IRoomRepository _roomRepository;

    public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<GetRoomByIdResponse?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id);
        
        if (room is null)
            return null;

        return new GetRoomByIdResponse(room.Id, room.Name);
    }
}
