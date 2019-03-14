using System;
using personExampleCorrect.Repositories;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace personExampleCorrect
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            //testing database read
            PersonRepository personRepository = new PersonRepository();
            //var persons = personRepository.Read();
            //var person = personRepository.ReadById(1234);
            CreatePerson();
            ReadByCity();
            for (int i = 0; i< 100; i++)
            {
                ReadById(i * 2);
            }
            //foreach(var p in person)
            //{
            //    Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName}");
            //}
            
        }
        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Lontoo");

            foreach (var p in persons)
            {

                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }
            Console.WriteLine("------------------------------");
        }
        static void ReadById (long id)
        {
            var person = _personRepository.ReadById(id);
            if (person == null)
            {
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy.");

            }
            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.City}");
        }
        static void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "james";
            person.LastName = "Bond";
            person.City = "Lontoo";
            person.ShoeSize = 45;
            _personRepository.Create(person);
        }

    }
}
