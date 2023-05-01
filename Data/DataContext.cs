using FilmSystemMinimalApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmSystemMinimalApi.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonChoice> PersonChoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // REMOTE:
            // optionsBuilder.UseSqlServer("Server=tcp:dev.kjeldcon.se;Database=dev_testdb1;User ID=SA;Password=Password123!;Trusted_Connection=False;Encrypt=False;");
            // LOCAL:
            optionsBuilder.UseSqlServer("Data Source=IQBALHOSSAI28BC; Initial Catalog=MovieDbMinimalApi;Integrated Security=true");
        }
    }
}
