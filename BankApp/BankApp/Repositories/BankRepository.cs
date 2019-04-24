using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly  BankdbContext _BankdbContext = new BankdbContext();

        public void Create(Bank bank)
        {
            string sql = $"INSERT INTO BANK (ID, NAME, BIC" +
                $"VALUES ({bank.Id}, {bank.Name}, {bank.BIC})";
            _BankdbContext.Add(bank);
            _BankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedBank = ReadById(id);
            if (deletedBank != null)
            {
                _BankdbContext.Remove(deletedBank);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        public List<Bank> ReadAll()
        {
            //KATSO KUVA PUHELIMESTA**
            var banks = _BankdbContext.Bank
                .Include(p =>p.Account)
                .ToList();
            foreach (var p in banks)
            {
                Console.WriteLine($"BANK ID: {p.Id} BANK NAME: {p.Name} BIC: {p.BIC}");
               
            }
            return banks;
        }

        public void Update(long id, Bank bank)
        {

            var updateBank = ReadById(id);
            if (updateBank != null)
            {
                _BankdbContext.Update(bank);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Pankkia ei ole olemassa!");
            }
        }    
        public Bank ReadById(long id)
        {
            var bank = _BankdbContext.Bank.Find(id);
            return bank;
        }

    }
}
