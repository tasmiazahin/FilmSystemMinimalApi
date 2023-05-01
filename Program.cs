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
            

            app.MapGet("api/person", () =>
            {
                PersonRepository personRepo = new PersonRepository(new DataContext());
                return personRepo.GetAll();
            })
            .WithName("GetPerson");

            app.MapGet("api/genre", () =>
            {
                GenreRepository genreRepo = new GenreRepository(new DataContext());
                return genreRepo.GetAll();

            })
            .WithName("GetGenre");

            app.MapGet("api/personchoice", () =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());
                return personchoiceRepo.GetAll();
            })
            .WithName("GetPersonChoice");

            app.Run();
        }
    }
}