using Application.Rooms.DeleteRoom;
using Application.Rooms.CreateRoom;
using Application.Rooms.ListRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class RoomController : ControllerBase
    {

        private readonly ILogger<RoomController> _logger;
        private readonly ISender _sender;

        public RoomController(ILogger<RoomController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            try
            {
                var rooms = await _sender.Send(new ListRoomsQuery());
                return Ok(rooms);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRoomCommand command)
        {
            try
            {
                await _sender.Send(command);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _sender.Send(new DeleteRoomCommand(id));
                return Ok("Room has been deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}