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
            //var persons = personRepository.Read();
            //var person = personRepository.ReadById(1234);
            //CreatePerson();
            //ReadByCity();
            //for (int i = 0; i< 100; i++)
            //{
            //    ReadById(i * 2);
            //}
            //foreach(var p in person)
            //{
            //    Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName}");
            //}

            // UpdatePerson();


            // DeletePerson(5001);
            string choise = null;
            do
            {
                choise = UserInterface();

                switch (choise.ToUpper())
                {
                    case "Q":
                        {

                            CreatePerson();

                            
                            break;
                        }

                    case "W":
                        {

                            break;
                        }
                    case "E":
                        {
                            break;
                        }


                }

            } while (choise.ToUpper() != "X");

            string UserInterface()
            {
                Console.WriteLine("\n Lisää tietokantaan uusi tietue: [Q] ");
                Console.WriteLine("\n Lue tietokannasta tietoja [W]");
                Console.WriteLine("\n Päivitä henkilön tietoja: [E]");
                Console.WriteLine("\n ");
                Console.WriteLine("\n Paina [X] jos haluat sulkea ohjelman.");
                return Console.ReadLine();
            }
        }

    
        static void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(5001);
            updatePerson.FirstName = "James";
            updatePerson.DateOfBirth = new DateTime(1960, 1, 1);
            _personRepository.Update(5001, updatePerson);
        }
        static void DeletePerson(long id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
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
            
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy.");

            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.City}");
        }
        static void CreatePerson()
        {
            Person person = new Person();
            Console.WriteLine("Lisää henkilö listaan.");
            Console.WriteLine("Anna etunimi");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Anna sukunimi");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Anna kotikaupunki");
            person.City = Console.ReadLine();
            Console.WriteLine("Kengännumero");
            person.ShoeSize = 45;
            _personRepository.Create(person);
        }

    }
}
