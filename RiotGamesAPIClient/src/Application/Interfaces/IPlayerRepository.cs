using RiotGamesAPIClient.src.Application.Models;
using static RiotGamesAPIClient.src.Infrastructure.Services.Responses.RiotMatchAPIResponse;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<Player> GetPlayerByNameAsync(string gameName, string tagLine);

        public Task<List<Participant>> GetMatchListByPuuidAsync(string puuid);
    }
}
