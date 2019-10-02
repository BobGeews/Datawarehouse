using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using personExampleCorrect;

namespace personExampleCorrect.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();


        public void Create(Person person)
        {
            string sql = $"INSERT INTO PERSON (Firstname, LastName, City, Shoesize" +
                $"VALUES ({person.FirstName}, {person.LastName}, {person.City}, {person.ShoeSize})";

            _persontestdbContext.Add(person);
            _persontestdbContext.SaveChanges();

        }

        public void Delete(long id)
        {
            //delete*from person where id ={id} sql lause
            var deletedPerson = ReadById(id);
            if (deletedPerson != null)
            {
                _persontestdbContext.Remove(deletedPerson);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public List<Person> ReadByCity(string city)
        {
            var persons = _persontestdbContext.
                Person.
                Where(p => p.City == city).
                ToListAsync().
                Result;
            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _persontestdbContext.Person.Find(id);
            return person;
        }

        public void Update(long id, Person person)
        {
            var updatePersons = ReadById(id);
            if (updatePersons != null)
            {
                _persontestdbContext.Update(person);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Henkilöä ei ole olemassa!");
            }
        }
    }
}
