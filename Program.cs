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

            // Get all person
            app.MapGet("api/person", () =>
            {
                PersonRepository personRepo = new PersonRepository(new DataContext());
                return personRepo.GetAll();
            })
            .WithName("GetPerson");

            // get all people that matches with first or last name
            app.MapGet("api/person/search", (string searchtext) =>
            {
                PersonRepository personRepo = new PersonRepository(new DataContext());
                return personRepo.SearchByName(searchtext);
            })
           .WithName("GetPersonByName");


            // get all people by page nuber 
            app.MapGet("api/person/{pageNumber}", (int pageNumber) =>
            {
                PersonRepository personRepo = new PersonRepository(new DataContext());
                return personRepo.GetPersonByPageNumber(pageNumber, 10);
            })
           .WithName("GetPersonByPageNumber");

            // Add a person
            app.MapPost("api/person", (Person person) =>
            {
                DataContext dataContext = new DataContext();
                PersonRepository personRepo = new PersonRepository(dataContext);

                personRepo.Create(person);

                // SaveChanges does not available in PersonRepository 
                dataContext.SaveChanges();
            }).WithName("AddPerson"); ;

           
            // Get all Genre
             app.MapGet("api/genre", () =>
            {
                GenreRepository genreRepo = new GenreRepository(new DataContext());
                return genreRepo.GetAll();

            })
            .WithName("GetGenre");


            // Add genre 
            app.MapPost("api/genre", (Genre genre) =>
            {
                DataContext dataContext = new DataContext();
                GenreRepository genreRepo = new GenreRepository(dataContext);

                genreRepo.Create(genre);
                dataContext.SaveChanges();
            }).WithName("AddGenre"); 


            // Get all record from PersonChoice table
            app.MapGet("api/personchoice", () =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());
                return personchoiceRepo.GetAll();
            })
            .WithName("GetPersonChoice");


            // Get all of movies and genre attached to a person
            app.MapGet("api/personchoice/{personid}", (int id) =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());
                return personchoiceRepo.GetByCondition(pc=>pc.PersonId == id);

            }).WithName("GetPersonChoiceByPerdonId");


            // Get list of genre connect to a person (Returns list of string )
            app.MapGet("api/personchoice/genre/{personid}", (int id) =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());

                // make a distinct genre list
               return  personchoiceRepo.GetGenreByPersonId(id).Select(pc=>pc.Genre.Title).Distinct();

            }).WithName("GetGenreByPerdonId");


            // get  download links of movies connected to a person (Returns list of string )
            app.MapGet("api/personchoice/movie/{personid}", (int id) =>
            {
                PersonChoiceRepository personchoiceRepo = new PersonChoiceRepository(new DataContext());
                return personchoiceRepo.GetPersonChoiceByPersonId(id).Select(pc => pc.MovieLink).ToList();

            }).WithName("GetMovieLinkByPerdonId");

            // add a record in personchoice table which includes rating, movie link and genre and connected to a person.
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