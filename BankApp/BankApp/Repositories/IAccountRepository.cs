using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        void Create(Account account);
        List<Account> ReadAll();
        void Update(long id, Account account);
        void Delete(long id);
        Account ReadById(long id);
    }
}
