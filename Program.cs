using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;
using FilmSystemMinimalApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmSystemMinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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


            app.MapPost("/person", (Person person) =>
            {
                DataContext dataContext = new DataContext();
                PersonRepository personRepo = new PersonRepository(dataContext);

                personRepo.Create(person);
                dataContext.SaveChanges();
            }).WithName("AddPerson"); ;

           

             app.MapGet("api/genre", () =>
            {
                GenreRepository genreRepo = new GenreRepository(new DataContext());
                return genreRepo.GetAll();

            })
            .WithName("GetGenre");

            app.MapPost("/grnre", (Genre genre) =>
            {
                DataContext dataContext = new DataContext();
                GenreRepository genreRepo = new GenreRepository(dataContext);

                genreRepo.Create(genre);
                dataContext.SaveChanges();
            }).WithName("AddGenre"); 




            app.MapGet("api/personchoice", () =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());
                return personchoiceRepo.GetAll();
            })
            .WithName("GetPersonChoice");

            app.MapPost("/personChoice", (PersonChoice personChoice) =>
            {
                DataContext dataContext = new DataContext();
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(dataContext);

               
                personchoiceRepo.Create(personChoice);
              
                dataContext.SaveChanges();
            }).WithName("AddPersonChoice");

            app.Run();
        }
    }
}