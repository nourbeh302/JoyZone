using Application.Reservations.ListReservations;
using Application.Reservations.CreateReservation;
using Application.Reservations.GetReservationById;
using Application.Reservations.CancelReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ReservationController : ControllerBase
    {

        private readonly ILogger<ReservationController> _logger;
        private readonly ISender _sender;

        public ReservationController(ILogger<ReservationController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            try
            {
                var reservations = await _sender.Send(new ListReservationsQuery());
                return Ok(reservations);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var reservation = await _sender.Send(new GetReservationByIdQuery(id));
                return Ok(reservation);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateReservationCommand command)
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

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Cancel(CancelReservationCommand command)
        {
            try
            {
                await _sender.Send(command);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}