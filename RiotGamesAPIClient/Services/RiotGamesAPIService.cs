using Microsoft.Net.Http.Headers;
using RiotGamesAPIClient.Models;
using System.Net;
using System.Text.Json;

namespace RiotGamesAPIClient.Services
{
    public class RiotGamesAPIService
    {
        private readonly HttpClient _httpClient;


        public RiotGamesAPIService(HttpClient httpClient)
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
            } else
            {
                return null;
            }
        }
    }
}
