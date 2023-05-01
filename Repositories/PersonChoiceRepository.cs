using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;

namespace FilmSystemMinimalApi.Repositories
{
    public class PersonChoiceRepository : RepositoryBase<PersonChoice>, IPersonChoiceRepository
    {
        public PersonChoiceRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
