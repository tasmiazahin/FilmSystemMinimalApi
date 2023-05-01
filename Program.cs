using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmSystemMinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<DataContext>(option =>
            //{
            //    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});

            // Add services to the container.
            builder.Services.AddAuthorization();

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

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");

            app.MapGet("api/person", () =>
            {
                //var person = await context.Persons.ToListAsync();
                //return person;

                PersonRepository personRepo = new PersonRepository(new DataContext());
                return personRepo.GetAll();
            })
            .WithName("GetPerson");

            //app.MapGet("api/genre", async (DataContext context) =>
            //{
            //    var genre = await context.Genres.ToListAsync();
            //    return genre;
            //})
            //.WithName("GetGenre");

            //app.MapGet("api/personchoice", async (DataContext context) =>
            //{
            //    var personChoice = await context.PersonChoices.ToListAsync();
            //    return personChoice;
            //})
            //.WithName("GetPersonChoice");

            app.Run();
        }
    }
}