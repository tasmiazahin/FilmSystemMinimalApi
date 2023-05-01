using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;

namespace FilmSystemMinimalApi.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
