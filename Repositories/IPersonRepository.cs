﻿using FilmSystemMinimalApi.Model;

namespace FilmSystemMinimalApi.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> SearchByName(string searchText);

        IEnumerable<Person> GetPersonByPageNumber(int pageNumber, int pageSize);
    }
}
