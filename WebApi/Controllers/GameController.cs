using Application.Games.CreateGame;
using Application.Games.ListGames;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Games.GetGameById;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class GameController : ControllerBase
    {

        private readonly ILogger<GameController> _logger;
        private readonly ISender _sender;

        public GameController(ILogger<GameController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            try
            {
                var games = await _sender.Send(new ListGamesQuery());
                return Ok(games);
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
                var game = await _sender.Send(new GetGameByIdQuery(id));
                return Ok(game);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateGameCommand command)
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
    }
}