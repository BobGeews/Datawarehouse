using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
   public interface IBankRepository
    {
        //CRUD
       void Create(Bank bank);
        List<Bank> ReadAll();
        void Update(long id, Bank bank);
        void Delete(long id);
        Bank ReadById(long id);
        

    }
}
