using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Infrastructure.Services.Responses;
using System.Net;

namespace RiotGamesAPIClient.src.Infrastructure.Services
{
    public class RiotAccountAPIService : IRiotAccountAPIService
    {
        private readonly HttpClient _httpClient;
        public RiotAccountAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<RiotAccountAPIResponse> GetAccountByNameAsync(string gameName, string tagLine)
        {
            var message = await _httpClient.GetAsync($"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                var APIResponse = await message.Content.ReadFromJsonAsync<RiotAccountAPIResponse>();
                return APIResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
