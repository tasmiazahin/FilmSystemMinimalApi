﻿using FilmSystemMinimalApi.Data;
using FilmSystemMinimalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmSystemMinimalApi.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext): base(dataContext)
        { 
        }

        public IEnumerable<Person> SearchByName(string searchText)
        {
            var context = new DataContext();
            return context.Persons.Where(x => (x.FirstName + " " + x.LastName).Contains(searchText));
        }


        public IEnumerable<Person> GetPersonByPageNumber(int pageNumber, int pageSize)
        {
            var context = new DataContext();
            return context.Persons.Skip((pageNumber-1)*pageSize).Take(pageSize);
        }
    }
}
