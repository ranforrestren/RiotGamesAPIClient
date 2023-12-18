
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RiotGamesAPIClient.Models;

namespace RiotGamesAPIClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var conStrBuilder = new SqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("DefaultConnection"));
            conStrBuilder.DataSource = builder.Configuration["SQLExpressServerName"];
            Console.WriteLine(conStrBuilder.ToString());
            var connectionString = conStrBuilder.ConnectionString;
            builder.Services.AddDbContext<PlayerDbContext>(options => options.UseSqlServer(connectionString));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
