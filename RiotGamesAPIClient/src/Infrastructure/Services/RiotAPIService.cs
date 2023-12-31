using RiotGamesAPIClient.Models;
using RiotGamesAPIClient.src.Application.Interfaces;
using System.Net;

namespace RiotGamesAPIClient.src.Infrastructure.Services
{
    public class RiotAPIService : IRiotAPIService
    {
        private readonly HttpClient _httpClient;

        public RiotAPIService(HttpClient httpClient)
        {
            var builder = WebApplication.CreateBuilder();
            _httpClient = httpClient;

            // using NA1 Platform ID 
            _httpClient.BaseAddress = new Uri("https://americas.api.riotgames.com");

            var apiKey = builder.Configuration["RiotAPIKey"];

            // adding HTTP Headers
            _httpClient.DefaultRequestHeaders.Add(
                "X-Riot-Token", apiKey);
        }

        public async Task<PlayerDTO> GetPlayerByNameAsync(string gameName, string tagLine)
        {
            var message = await _httpClient.GetAsync($"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
            Console.Write(message.Content.ReadAsStringAsync().Result);
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
