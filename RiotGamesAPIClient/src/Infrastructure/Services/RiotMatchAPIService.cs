using RiotGamesAPIClient.src.Application.Interfaces;
using System.Net;

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
            var message = await _httpClient.GetAsync($"/lol/match/v5/matches/by-puuid/{puuid}/ids");
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
    }
}
