using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
    interface ITransactionRepository
    {
        //CRUD
        void Create(Transaction transaction);
       
        void Update(long id, Transaction transaction);
        void Delete(long id);
        Transaction ReadById(long id);
    }
}
