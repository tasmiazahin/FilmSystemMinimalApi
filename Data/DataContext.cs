using FilmSystemMinimalApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmSystemMinimalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonChoice> PersonChoices { get; set; }
    }
}
