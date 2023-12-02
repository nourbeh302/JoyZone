using Domain.Rooms;
using MediatR;

namespace Application.Rooms.ListRooms;

public class ListRoomsQueryHandler : IRequestHandler<ListRoomsQuery, ListRoomsResponse>
{
    private readonly IRoomRepository _roomRepository;

    public ListRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ListRoomsResponse> Handle(ListRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.ListAsync();
        return new ListRoomsResponse(rooms);
    }
}
