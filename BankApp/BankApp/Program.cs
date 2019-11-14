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

            _bankRepository.ReadAll();
            Console.WriteLine("-----------------------------------------------------------");
            _customerRepository.ReadAll();
            Console.WriteLine("-----------------------------------------------------------");
            _accountRepository.ReadAll();
            Console.WriteLine("-----------------------------------------------------------");
    
            string userInput = null;
            string msg = "";

            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "1":
                        CreateBank();
                        msg = "Uusi pankki luotu";
                        break;
                    case "2":
                        UpdateBank();
                        msg = "Pankin tiedot päivitetty";
                        break;
                    case "3":
                        DeleteBank();
                        msg = "Pankki poistettu";
                        break;
                    case "4":
                        CreateCustomerAndAccount();
                        msg = "Asiakas ja tili luotu";
                        break;
                    case "5":
                        UpdateCustomer();
                        break;
                    case "6":
                        DeleteCustomer();
                        msg = "Pankin asiakkaat tulostettu";
                        break;
                    case "7":
                        CreateTransactionForCustomer();
                        msg = "Asiakkaan tiedot päivitetty";
                        break;
                    case "X":
                        msg = "Sovellus suljetaan";
                        break;
                    default:
                        msg = "Yritä uudestaan oikealla näppäimellä";
                        break;
                }
                Console.WriteLine(msg);
            } while (userInput.ToUpper() != "X");
        }
            static string Choise()
            {
                Console.WriteLine("[1] Lisää pankki\n[2] Päivitä pankki\n[3] Poista pankki\n[4] Lisää pankkiin asiakas ja tili\n[5] Päivitä asiakastietoja" +
                    "\n[6] Poista asiakas\n[7] Luo tilitapahtumia asiakkaalle\n[X] Sammuta sovellus");
                Console.Write("Valitse mitä tehdään: ");
                string choise = Console.ReadLine();
                return choise;
            }

        
        //Päivitä jo OLEMASSA OLEVAN pankin tietoja
        static void UpdateBank()
        {
            Console.Write("Anna päivitettävän pankin ID: ");
            long updatedBankid = Convert.ToInt64(Console.ReadLine());
            Bank updateBank = _bankRepository.ReadById(updatedBankid);
            Console.Write("Anna pankille uusi nimi: ");
            updateBank.Name = Console.ReadLine();
            updateBank.Id = updatedBankid;
            Console.Write("Anna pankille uusi BIC: ");
            updateBank.BIC = Console.ReadLine();
            _bankRepository.Update(updatedBankid, updateBank);
        }
        //Uuden pankin luominen
        static void CreateBank()
        {

            Bank newBank = new Bank();
            Console.Write("Anna Pankille nimi: ");
            newBank.Name = Console.ReadLine();
            Console.Write("Anna Pankille BIC: ");
            newBank.BIC = Console.ReadLine();
            Console.Write("Anna pankille ID: ");
            newBank.Id = Convert.ToInt64(Console.ReadLine());

            _bankRepository.Create(newBank);
        }
        //Pankin poistaminen
        static void DeleteBank()
        {
            Console.Write("Anna poistettavan pankin ID: ");
            long deletedBankid = Convert.ToInt64(Console.ReadLine());
            _bankRepository.Delete(deletedBankid);
        }
        //Asiakkaan nimen päivittäminen
        static void UpdateCustomer()
        {
            Console.Write("Anna asiakkaan ID: ");
            long updatedCustomerid = Convert.ToInt64(Console.ReadLine());
            Customer updateCustomer = _customerRepository.ReadById(updatedCustomerid);
            Console.Write("Anna asiakkaalle uusi etunimi: ");
            updateCustomer.Firstname = Console.ReadLine();
            Console.Write("Anna asiakkaalle uusi sukunimi: ");
            updateCustomer.Lastname = Console.ReadLine();
            _customerRepository.Update(updatedCustomerid, updateCustomer);
        }
        //Asiakkaan poistaminen
        static void DeleteCustomer()
        {
            Console.Write("Anna poistettavan asiakkaan ID: ");
            long deletedCustomerid = Convert.ToInt64(Console.ReadLine());
            _customerRepository.Delete(deletedCustomerid);

            _accountRepository.Delete(deletedCustomerid);


        }
        static void CreateCustomerAndAccount()
        {
            Customer newCustomer = new Customer();
            Console.Write("Syötä pankin id, johon asiakas kirjautuu: ");
            newCustomer.BankId = Convert.ToInt64(Console.ReadLine());
            Console.Write("Anna asiakkaalle ID: ");
            newCustomer.Id = Convert.ToInt64(Console.ReadLine());
            Console.Write("Anna uuden asiakkaan etunimi: ");
            newCustomer.Firstname = Console.ReadLine();
            Console.Write("Anna uuden asiakkaan sukunimi: ");
            newCustomer.Lastname = Console.ReadLine();

            _customerRepository.Create(newCustomer);

            Account newAccount = new Account();
            newAccount.BankId = newCustomer.BankId;
            newAccount.CustomerId = newCustomer.Id;
            Console.Write("Syötä uuden tilin IBAN: ");
            newAccount.IBAN = Console.ReadLine();
            Console.Write("Syötä uuden tilin nimi: ");
            newAccount.Name = Console.ReadLine();
            Console.Write("Tilille talletettavan rahan määrä: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            newAccount.Balance = amount;
            

            _accountRepository.Create(newAccount);
        }
        static void CreateTransactionForCustomer()
        {
            Transaction newTransaction = new Transaction();
            Console.Write("Syötä asiakkaan Id, kenelle haluat luoda uuden tilitapahtuman: ");
            long id = long.Parse(Console.ReadLine());
            var account = _accountRepository.ReadById(id);
            newTransaction.IBAN = account.IBAN;
            Console.Write("Syötä määrä: ");
            newTransaction.Amount = decimal.Parse(Console.ReadLine());

            account.Balance += newTransaction.Amount;

            _transactionRepository.Create(newTransaction);
        }
  
    }
}
