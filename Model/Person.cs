using System.ComponentModel.DataAnnotations;

namespace FilmSystemMinimalApi.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public List<PersonChoice> PersonChoices { get; set; }
    }
}
