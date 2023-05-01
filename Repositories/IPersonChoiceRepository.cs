using FilmSystemMinimalApi.Model;

namespace FilmSystemMinimalApi.Repositories
{
    public interface IPersonChoiceRepository : IRepositoryBase<PersonChoice>
    {
        IEnumerable<PersonChoice> GetGenreByPersonId(int personId);
        IEnumerable<PersonChoice> GetPersonChoiceByPersonId(int personId);

    }
}
