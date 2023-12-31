using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Application.Models;
using RiotGamesAPIClient.src.Infrastructure.EFCore.DbContexts;

namespace RiotGamesAPIClient.src.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerDbContext _context;
        private readonly IRiotAccountAPIService _riotAccountAPIService;
        private readonly IRiotSummonerAPIService _riotSummonerAPIService;
        public PlayerRepository(PlayerDbContext context, IRiotAccountAPIService RiotAccountAPIService, IRiotSummonerAPIService RiotSummonerAPIService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _riotAccountAPIService = RiotAccountAPIService ?? throw new ArgumentNullException(nameof(RiotAccountAPIService));
            _riotSummonerAPIService = RiotSummonerAPIService ?? throw new ArgumentNullException(nameof(RiotSummonerAPIService));
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
                var accountAPIResponse = await _riotAccountAPIService.GetAccountByNameAsync(gameName, tagLine);
                if (accountAPIResponse == null)
                {
                    return null;
                }
                else
                {
                    // second HTTPRequest to get summoner data from UUID
                    string puuid = accountAPIResponse.puuid;
                    var summonerAPIResponse = await _riotSummonerAPIService.GetSummonerByPuuidAsync(puuid);
                    // create new player from the API responses
                    var newPlayer = new Player();
                    newPlayer.PlayerRiotUUID = accountAPIResponse.puuid;
                    newPlayer.PlayerRiotName = accountAPIResponse.gameName;
                    newPlayer.PlayerRiotTagline = accountAPIResponse.tagLine;
                    newPlayer.PlayerRiotAccountId = summonerAPIResponse.accountId;
                    newPlayer.PlayerProfileIconId = summonerAPIResponse.profileIconId;
                    newPlayer.PlayerSummonerId = summonerAPIResponse.id;
                    newPlayer.PlayerSummonerLevel = summonerAPIResponse.summonerLevel;
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
