using Microsoft.AspNetCore.Mvc;
using RiotGamesAPIClient.src.Application.Models;
using RiotGamesAPIClient.src.Infrastructure.UnitOfWork;

namespace RiotGamesAPIClient.src.Application.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<Player> GetPlayerByNameAsync(string gameName, string tagLine);
    }
}
