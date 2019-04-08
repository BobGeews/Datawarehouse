using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PersonPhoneApp
{
    class PersonPhoneRepositories : IPersonPhoneNumbers
    {

        private readonly PersonphonenumberContext _PersonphonenumberContext = new PersonphonenumberContext();

        public void Create(Phone phone)
        {
            string sql = $"INSERT INTO PHONE (ID, TYPE, NUMBER, PERSONID" +
                 $"VALUES ({phone.id}, {phone.Type}, {phone.Number}, {phone.Personid})";
            _PersonphonenumberContext.Add(phone);
            _PersonphonenumberContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deleteNumber = ReadById(id);
            if (deleteNumber != null)
            {
                _PersonphonenumberContext.Remove(deleteNumber);
                _PersonphonenumberContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public List<Phone> ReadAll()
        {
            var numbers = _PersonphonenumberContext.Phone
                .Include(p => p.Person)
                .ToList();
            foreach (var p in numbers)
            {
                Console.WriteLine($"PHONE ID: {p.id} PHONE TYPE: {p.Type} PHONENUMBER: {p.Number} PHONE PERSON ID: {p.Personid} ");

            }
            return numbers;
        }

        public void Update(long id, Phone phone)
        {
            var updatePhone = ReadById(id);
            if (updatePhone != null)
            {
                _PersonphonenumberContext.Update(phone);
                _PersonphonenumberContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Numeroa ei ole olemassa!");
            }
        }

        public Phone ReadById(long id)
        {
            var phone = _PersonphonenumberContext.Phone.Find(id);
            return phone;
        }

        public List<Person> ReadAllPersons()
        {
            var persons = _PersonphonenumberContext.Person
                .Include(p => p.Phone)
                .ToList();
            foreach (var p in persons)
            {
                Console.WriteLine($"PERSON ID: {p.id} PERSON NAME: {p.Name} PERSONAGE: {p.Age} ");

            }
            return persons;
        }

        public Person ReadByPersonId(long id)
        {
            var person = _PersonphonenumberContext.Person.Find(id);
            return person;
        }

        public void DeletePerson(long id)
        {
            var deleteNumber = ReadByPersonId(id);
            if (deleteNumber != null)
            {
                _PersonphonenumberContext.Remove(deleteNumber);
                _PersonphonenumberContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public void CreatePerson(Person person)
        {
            string sql = $"INSERT INTO PERSON (ID, NAME, AGE" +
                 $"VALUES ({person.id}, {person.Name}, {person.Age})";
            _PersonphonenumberContext.Add(person);
            _PersonphonenumberContext.SaveChanges();
        }

        public void UpdatePerson(long id, Person person)
        {
            var updatePerson = ReadByPersonId(id);
            if (updatePerson != null)
            {
                _PersonphonenumberContext.Update(person);
                _PersonphonenumberContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Henkilöä ei ole olemassa!!");
            }
        }
    }
}
