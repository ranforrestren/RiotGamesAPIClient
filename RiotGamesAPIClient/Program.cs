
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.src.Application.Interfaces;
using RiotGamesAPIClient.src.Infrastructure.Repositories;
using RiotGamesAPIClient.src.Infrastructure.Services;
using RiotGamesAPIClient.src.Infrastructure.UnitOfWork;
using System.Net.Http;

namespace RiotGamesAPIClient
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
            // create the RiotAPIService and configure its HttpClient
            // inject in the API key from the Secrets.json
            var apiKey = builder.Configuration["RiotAPIKey"];
            builder.Services.AddHttpClient<IRiotAPIService, RiotAPIService>(
                client =>
                {
                // set base address of typed client to Americans region of Riot Games API
                client.BaseAddress = new Uri("https://americas.api.riotgames.com");
                Console.WriteLine(client.BaseAddress);
                // adding HTTP Headers
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
