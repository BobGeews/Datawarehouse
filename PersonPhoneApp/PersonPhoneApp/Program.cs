using System;
using Microsoft.EntityFrameworkCore;


namespace PersonPhoneApp
{
    class Program
    {
        private static readonly PersonPhoneRepositories _PersonPhoneRepositories = new PersonPhoneRepositories();
        static void Main(string[] args)
        {
            //Kun luot uuden numero varmista, että newNumber.Personid vastaa newPerson.id:n kanssa!!! 
            //
             

            Phone newNumber = new Phone();
            newNumber.Number = "111111111111";
            newNumber.Type = "HOME";
            newNumber.id = 6;
            newNumber.Personid = 3;

            Person newPerson = new Person();
            newPerson.id = 3;
            newPerson.Age = 30;
            newPerson.Name = "Jaska Jokunen";


            // _PersonPhoneRepositories.CreatePerson(newPerson);
            //_PersonPhoneRepositories.Create(newNumber);

            //_PersonPhoneRepositories.DeletePerson(5);
            _PersonPhoneRepositories.ReadAll();
            _PersonPhoneRepositories.ReadAllPersons();
            //_PersonPhoneRepositories.Delete(5);
            //_PersonPhoneRepositories.ReadAll();



        }
        static void UpdateNumber()
        {
        Phone updateNumber= _PersonPhoneRepositories.ReadById(1);
            updateNumber.Number = "000000000000";
            updateNumber.Type = "Läähätysnumero";
            
            _PersonPhoneRepositories.Update(1, updateNumber);
        }
        static void UpdatePerson()
        {
            Person updatePerson = _PersonPhoneRepositories.ReadByPersonId(1);
            updatePerson.Age = 12;
            updatePerson.Name = "Keijo Kaalee";

            _PersonPhoneRepositories.UpdatePerson(1, updatePerson);
        }


    }
}
