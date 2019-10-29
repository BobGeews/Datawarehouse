using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _BankdbContext = new BankdbContext();

        public void Create(Account account)
        {
            string sql = $"INSERT INTO ACCOUNT (IBAN, NAME, BANKID, CUSTOMERID, BALANCE" +
                $"VALUES ({account.IBAN}, {account.Name}, {account.BankId}, {account.CustomerId}, {account.Balance})";
            _BankdbContext.Add(account);
            _BankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedAccount = ReadById(id);
            if (deletedAccount != null)
            {
                _BankdbContext.Remove(deletedAccount);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public List<Account> ReadAll()
        {
            //KATSO KUVA PUHELIMESTA**
            var accounts = _BankdbContext.Account
                .Include(p => p.Bank)
                .ToList();
            foreach (var p in accounts)
            {
                Console.WriteLine($"ACCOUNT IBAN: {p.IBAN} ACCOUNT NAME: {p.Name} BANK ID: {p.BankId} CUSTOMER ID: {p.CustomerId} BALANCE: {p.Balance} ");

            }
            return accounts;
        }

        public void Update(long id, Account account)
        {

            var updateAccount = ReadById(id);
            if (updateAccount != null)
            {
                _BankdbContext.Update(account);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Tiliä ei ole olemassa!");
            }
        }
        public Account ReadById(long id)
        {
            var account = _BankdbContext.Account.Find(id);
            return account;
        }

    }

}
}
