using RiotGamesAPIClient.src.Infrastructure.Services.Responses;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IRiotSummonerAPIService
    {
        Task<RiotSummonerAPIResponse> GetSummonerByPuuidAsync(string puuid);
    }
}
