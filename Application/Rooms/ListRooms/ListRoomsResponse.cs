using Domain.Rooms;

namespace Application.Rooms.ListRooms;

public record ListRoomsResponse(IReadOnlyList<Room> Rooms);
