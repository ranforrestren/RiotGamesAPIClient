using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Infrastructure.Services.Responses;
using System.Diagnostics;
using System.Net;
using static RiotGamesAPIClient.src.Infrastructure.Services.Responses.RiotMatchAPIResponse;

namespace RiotGamesAPIClient.src.Infrastructure.Services
{
    public class RiotMatchAPIService : IRiotMatchAPIService
    {
        private readonly HttpClient _httpClient;
        public RiotMatchAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<string>> GetMatchListByPuuidAsync(string puuid)
        {
            var message = await _httpClient.GetAsync($"/lol/match/v5/matches/by-puuid/{puuid}/ids?queue=420&count=10");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                var APIResponse = await message.Content.ReadFromJsonAsync<List<string>>();
                return APIResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<Participant> GetMatchDetailsByMatchIdAndPuuidAsync(string matchId, string puuid)
        {
            var message = await _httpClient.GetAsync($"/lol/match/v5/matches/{matchId}");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                var APIResponse = await message.Content.ReadFromJsonAsync<RiotMatchAPIResponse>();
                var participant = APIResponse.info.participants.Where(p => p.puuid == puuid).FirstOrDefault();
                return participant;
            }
            else
            {
                return null;
            }
        }
    }
}
