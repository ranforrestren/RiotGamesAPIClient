using RiotGamesAPIClient.src.Infrastructure.Services.Responses;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IRiotAccountAPIService
    {
        Task<RiotAccountAPIResponse> GetAccountByNameAsync(string gameName, string tagLine);
    }
}
