using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _BankdbContext = new BankdbContext();

        public void Create(Transaction transaction)
        {
            string sql = $"INSERT INTO TRANSACTION (ID, IBAN, AMOUNT, TIMESTAMP" +
                $"VALUES ({transaction.Id}, {transaction.IBAN}, {transaction.Amount}, {transaction.TimeStamp})";
            _BankdbContext.Add(transaction);
            _BankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedtransaction = ReadById(id);
            if (deletedtransaction != null)
            {
                _BankdbContext.Remove(deletedtransaction);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut.");
            }
        }

        

        public void Update(long id, Transaction transaction)
        {

            var updateTransaction = ReadById(id);
            if (updateTransaction != null)
            {
                _BankdbContext.Update(transaction);
                _BankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti.");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui. Tilitapahtumaa ei ole olemassa!");
            }
        }
        public Transaction ReadById(long id)
        {
            var transaction = _BankdbContext.Transaction.Find(id);
            return transaction;
        }

    }

}

