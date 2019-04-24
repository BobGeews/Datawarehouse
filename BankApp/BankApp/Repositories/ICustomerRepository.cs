using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
    interface ICustomerRepository
    {
        //CRUD
        void Create(Customer customer);
        List<Customer> ReadAll();
        void Update(long id, Customer customer);
        void Delete(long id);
        Customer ReadById(long id);
    }
}
