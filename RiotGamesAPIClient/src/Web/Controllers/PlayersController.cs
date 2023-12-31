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
        [HttpGet("players/byname/{gameName}/{tagLine}")]
        public async Task<ActionResult<Player>> GetPlayerByNameAsync(string gameName, string tagLine)
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

        // GET: api/Matches/byPuuid
        [HttpGet("matches/bypuuid/{puuid}")]
        public async Task<ActionResult<List<string>>> GetMatchesByPuuidAsync(string puuid)
        {
            var matches = await _playerRepository.GetMatchesByPuuidAsync(puuid);
            if (matches == null)
            {
                return NotFound();
            }
            else
            { 
                return matches;
            }
        }
    }
}
