using FilmSystemMinimalApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmSystemMinimalApi.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonChoice> PersonChoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=MovieDbMinimalApi;Integrated Security=true");
        }
    }
}
