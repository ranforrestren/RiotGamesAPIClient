
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Infrastructure.EFCore.DbContexts;
using RiotGamesAPIClient.src.Infrastructure.Repositories;
using RiotGamesAPIClient.src.Infrastructure.Services;
using System.Net.Http;

namespace RiotGamesAPIClient.src.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AllowVueFrontend = "_allowVueFrontend";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowVueFrontend,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost")
                        .AllowAnyOrigin();
                    });
            });
            builder.Services.AddControllers();
            var conStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("DefaultConnection"));
            // create the DbContext 
            conStrBuilder.DataSource = builder.Configuration["SQLExpressServerName"];
            var connectionString = conStrBuilder.ConnectionString;
            builder.Services.AddDbContext<PlayerDbContext>(options => options.UseSqlServer(connectionString));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // create the RiotAPIServices and configure their HttpClients as transient typed clients
            // inject in the API key from the Secrets.json
            var apiKey = builder.Configuration["RiotAPIKey"];
            builder.Services.AddHttpClient<IRiotAccountAPIService, RiotAccountAPIService>(
                client =>
                {
                    // adding base address
                    client.BaseAddress = new Uri("https://americas.api.riotgames.com");
                    // adding HTTP Headers (API key)
                    client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
                });
            builder.Services.AddHttpClient<IRiotSummonerAPIService, RiotSummonerAPIService>(
                client =>
                {
                    // adding base address
                    client.BaseAddress = new Uri("https://na1.api.riotgames.com");
                    // adding HTTP Headers (API key)
                    client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            });
            builder.Services.AddHttpClient<IRiotMatchAPIService, RiotMatchAPIService>(
                client =>
                {
                    // adding base address
                    client.BaseAddress = new Uri("https://americas.api.riotgames.com");
                    // adding HTTP Headers (API key)
                    client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            });
            // create the Repository
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowVueFrontend);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
