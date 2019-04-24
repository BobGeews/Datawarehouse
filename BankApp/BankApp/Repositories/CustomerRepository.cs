using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _BankdbContext = new BankdbContext();

        public void Create(Customer customer)
        {
            string sql = $"INSERT INTO CUSTOMER (ID, FIRSTNAME, LASTNAME, BANKID" +
                $"VALUES ({customer.Id}, {customer.Firstname}, {customer.Lastname}, {customer.BankId})";
            _BankdbContext.Add(customer);
            _BankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedCustomer = ReadById(id);
            if (deletedCustomer != null)
            {
                _BankdbContext.Remove(deletedCustomer);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public List<Customer> ReadAll()
        {
            var customers = _BankdbContext.Customer
                .Include(p => p.Account)
                .ToList();
            foreach (var p in customers)
            {
                Console.WriteLine($"CUSTOMER ID: {p.Id} CUSTOMER NAME: {p.Firstname} {p.Lastname} BANK ID: {p.BankId}");

            }
            return customers;
        }

        public Customer ReadById(long id)
        {
            var customer = _BankdbContext.Customer.Find(id);
            return customer;
        }

        public void Update(long id, Customer customer)
        {
            var updateCustomer = ReadById(id);
            if (updateCustomer != null)


            {
                _BankdbContext.Update(customer);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Asiakasta ei ole olemassa!");
            }
        }
    }
}
