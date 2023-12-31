using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Infrastructure.Services.Responses;
using System.Net.Http;
using System.Net;

namespace RiotGamesAPIClient.src.Infrastructure.Services
{
    public class RiotSummonerAPIService : IRiotSummonerAPIService
    {
        private readonly HttpClient _httpClient;
        public RiotSummonerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<RiotSummonerAPIResponse> GetSummonerByPuuidAsync(string puuid)
        {
            _httpClient.BaseAddress = new Uri("https://na1.api.riotgames.com");
            var message = await _httpClient.GetAsync($"/lol/summoner/v4/summoners/by-puuid/{puuid}");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                var APIResponse = await message.Content.ReadFromJsonAsync<RiotSummonerAPIResponse>();
                return APIResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
