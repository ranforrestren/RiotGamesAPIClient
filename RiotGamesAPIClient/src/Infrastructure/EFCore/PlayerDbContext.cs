using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.src.Application.Models;

namespace RiotGamesAPIClient.src.Infrastructure.UnitOfWork
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
    }
}
