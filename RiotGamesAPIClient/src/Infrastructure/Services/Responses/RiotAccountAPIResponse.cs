namespace RiotGamesAPIClient.src.Infrastructure.Services.Responses
{
    // response for https://americas.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine} endpoint
    public class RiotAccountAPIResponse
    {
        public string puuid { get; set; } // pUUID
        public string gameName { get; set; } // gameName
        public string tagLine { get; set; } // tagLine
    }
}
