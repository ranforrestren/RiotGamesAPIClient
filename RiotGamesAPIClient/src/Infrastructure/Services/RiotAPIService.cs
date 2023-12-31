using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Application.Models;
using System.Net;

namespace RiotGamesAPIClient.src.Infrastructure.Services
{
    public class RiotAPIService : IRiotAPIService
    {
        private readonly HttpClient _httpClient;
        public RiotAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<PlayerDTO> GetPlayerByNameAsync(string gameName, string tagLine)
        {
            var message = await _httpClient.GetAsync($"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                var playerDTO = await message.Content.ReadFromJsonAsync<PlayerDTO>();
                return playerDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
