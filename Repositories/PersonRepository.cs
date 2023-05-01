using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;

namespace FilmSystemMinimalApi.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext): base(dataContext)
        {

        }
    }
}
