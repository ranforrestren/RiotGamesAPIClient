using RiotGamesAPIClient.src.Application.Models;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<Player> GetPlayerByNameAsync(string gameName, string tagLine);
    }
}
