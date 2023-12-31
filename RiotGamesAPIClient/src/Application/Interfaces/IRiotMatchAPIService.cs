using static RiotGamesAPIClient.src.Infrastructure.Services.Responses.RiotMatchAPIResponse;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IRiotMatchAPIService
    {
        Task<List<string>> GetMatchListByPuuidAsync(string puuid);

        Task<Participant> GetMatchDetailsByMatchIdAndPuuidAsync(string matchId, string puuid);
    }
}
