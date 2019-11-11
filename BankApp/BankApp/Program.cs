using System;
using BankApp.Repositories;
using System.IO;

namespace BankApp
{
    class Program
    {
        private static readonly BankRepository _bankRepository = new BankRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();
        private static readonly AccountRepository _accountRepository = new AccountRepository();

        static void Main(string[] args)
        {
            
            //bankRepository.Create(newBank);
            //UpdateBank(5);
            _bankRepository.ReadAll();
            _customerRepository.ReadAll();
            _accountRepository.ReadAll();
            _transactionRepository.ReadById(1);

        }
        //Päivitä jo OLEMASSA OLEVAN pankin tietoja
        public void UpdateBank(long id)
        {
            Bank updateBank = _bankRepository.ReadById(5);
            updateBank.Name = "Roope Ankan Pankki";
            updateBank.Id = 5;
            updateBank.BIC = "123045";
            _bankRepository.Update(5, updateBank);
        }
        //Uuden pankin luominen
        public void Create(Bank bank)
        {
            
            Bank newBank = new Bank();
            newBank.Name = "S-Pankki";
            newBank.Id = 6;
            newBank.BIC = "1234567";
        }

    }
}
