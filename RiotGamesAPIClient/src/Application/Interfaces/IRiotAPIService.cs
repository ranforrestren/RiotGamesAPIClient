using RiotGamesAPIClient.Models;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IRiotAPIService
    {
        Task<PlayerDTO> GetPlayerByNameAsync(string gameName, string tagLine);
    }
}
