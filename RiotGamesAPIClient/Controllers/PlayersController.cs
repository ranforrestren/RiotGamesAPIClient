﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.Models;
using RiotGamesAPIClient.Services;

namespace RiotGamesAPIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerDbContext _context;

        private readonly RiotGamesAPIService _riotGamesAPIService;

        public PlayersController(PlayerDbContext context, RiotGamesAPIService riotGamesAPIService)
        {
            _context = context;
            _riotGamesAPIService = riotGamesAPIService;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Players/byName/GAMENAME/TAGLINE
        [HttpGet("byName/{gameName}/{tagLine}")]
        public async Task<ActionResult<Player>> GetPlayerByName(string gameName, string tagLine)
        {
            // try to find existing player object with matching gameName and tagLine
            var player = await _context.Players
                .Where(e => e.PlayerRiotName == gameName && e.PlayerRiotTagline == tagLine)
                .FirstOrDefaultAsync();
            // create player if no match found
            if (player == null)
            {
                // create HTTPRequest to get player UUID and create player object otherwise
                var playerDTO = await _riotGamesAPIService.GetPlayerByNameAsync(gameName, tagLine);
                if (playerDTO == null)
                {
                    return NotFound();
                }
                else
                {
                    // create new player from playerDTO
                    var newPlayer = new Player();
                    newPlayer.PlayerRiotUUID = playerDTO.puuid;
                    newPlayer.PlayerRiotName = playerDTO.gameName;
                    newPlayer.PlayerRiotTagline = playerDTO.tagLine;
                    // and save to DB
                    _context.Players.Add(newPlayer);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetPlayer), new { id = newPlayer.PlayerId }, newPlayer);
                }
            }
            else
            {
                return player;
            }
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
