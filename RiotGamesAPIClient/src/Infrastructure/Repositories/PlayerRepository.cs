using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Application.Models;
using RiotGamesAPIClient.src.Infrastructure.EFCore.DbContexts;

namespace RiotGamesAPIClient.src.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerDbContext _context;
        private readonly IRiotAPIService _riotAPIService;
        public PlayerRepository(PlayerDbContext context, IRiotAPIService RiotAPIService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _riotAPIService = RiotAPIService ?? throw new ArgumentNullException(nameof(RiotAPIService));
        }
        public async Task<Player> GetPlayerByNameAsync(string gameName, string tagLine)
        {
            // try to find existing player object with matching gameName and tagLine
            var player = await _context.Players
                .Where(e => e.PlayerRiotName == gameName && e.PlayerRiotTagline == tagLine)
                .FirstOrDefaultAsync();
            // create player if no match found
            if (player == null)
            {
                // create HTTPRequest to get player UUID and create player object otherwise
                var playerDTO = await _riotAPIService.GetPlayerByNameAsync(gameName, tagLine);
                if (playerDTO == null)
                {
                    return null;
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

                    return newPlayer;
                }
            }
            else
            {
                return player;
            }
        }
    }
}
