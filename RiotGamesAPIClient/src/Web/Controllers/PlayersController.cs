using Microsoft.AspNetCore.Mvc;
using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Application.Models;

namespace RiotGamesAPIClient.src.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }

        // GET: api/Players/byName/GAMENAME/TAGLINE
        [HttpGet("byName/{gameName}/{tagLine}")]
        public async Task<ActionResult<Player>> GetPlayerByName(string gameName, string tagLine)
        {
            var player = await _playerRepository.GetPlayerByNameAsync(gameName, tagLine);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                return player;
            }
        }
    }
}
