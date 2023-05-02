using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmSystemMinimalApi.Repositories
{
    public class PersonChoiceRepository : RepositoryBase<PersonChoice>, IPersonChoiceRepository
    {
        public PersonChoiceRepository(DataContext dataContext) : base(dataContext)
        {

        }

        // additional repository functions 
        public IEnumerable<PersonChoice> GetGenreByPersonId(int personId)
        {
            var context = new DataContext();
            return context.PersonChoices.Include(x => x.Genre).Where(pc => pc.PersonId == personId);
        }

        public IEnumerable<PersonChoice> GetPersonChoiceByPersonId(int personId)
        {
            var context = new DataContext();
            return context.PersonChoices.Where(pc => pc.PersonId == personId);
        }
    }
}
