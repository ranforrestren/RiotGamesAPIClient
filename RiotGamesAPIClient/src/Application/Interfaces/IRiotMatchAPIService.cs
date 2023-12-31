namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IRiotMatchAPIService
    {
        Task<List<string>> GetMatchListByPuuidAsync(string puuid);
    }
}
