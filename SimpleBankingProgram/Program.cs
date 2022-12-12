using SimpleBanking;
using System;

namespace SimpleBankingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple banking test go.");

            Console.WriteLine("Creating bank name Bank Cutter.");
            var bank = new Bank("Bank Cutter");

            Console.WriteLine("-----------------");
            Console.WriteLine("Creating Accounts");

            Console.WriteLine(bank.AddAccount("John", "Doe", SimpleBanking.Model.AccountTypes.Checking));
            Console.WriteLine(bank.AddAccount("Jacob", "Doe", SimpleBanking.Model.AccountTypes.InvestmentCorporate));
            Console.WriteLine(bank.AddAccount("Jingle", "Doe", SimpleBanking.Model.AccountTypes.InvestmentIndividual));
            Console.WriteLine(bank.AddAccount("Heimer", "Doe", SimpleBanking.Model.AccountTypes.Checking));

            Console.WriteLine("-----------------");
            Console.WriteLine("Depositing Money");
            Console.WriteLine("Happy Path");
            Console.WriteLine(bank.Deposit(1, 500.50));
            Console.WriteLine(bank.Deposit(2, 500.51));
            Console.WriteLine(bank.Deposit(3, 1500.52));
            Console.WriteLine(bank.Deposit(4, 500.52));
            Console.WriteLine("Unappy Path");
            Console.WriteLine(bank.Deposit(5, 500.52));
            Console.WriteLine(bank.Deposit(3, 0));
            Console.WriteLine(bank.Deposit(3, -1));

            Console.WriteLine("-----------------");
            Console.WriteLine("Check balances");
            Console.WriteLine(bank.GetBalance(1));
            Console.WriteLine(bank.GetBalance(2));
            Console.WriteLine(bank.GetBalance(3));
            Console.WriteLine(bank.GetBalance(4));

            Console.WriteLine("-----------------");
            Console.WriteLine("Withdrawing Money");
            Console.WriteLine("Happy Path");
            Console.WriteLine(bank.Withdraw(1, 25.25));
            Console.WriteLine(bank.Withdraw(2, 25.25));
            Console.WriteLine(bank.Withdraw(3, 25.25));
            Console.WriteLine(bank.Withdraw(4, 25.25));
            Console.WriteLine("Unappy Path");
            Console.WriteLine(bank.Withdraw(3, 600));
            Console.WriteLine(bank.Withdraw(1, 600));
            Console.WriteLine(bank.Withdraw(3, 0));
            Console.WriteLine(bank.Withdraw(3, -1));
            Console.WriteLine(bank.Withdraw(0, -1));



            Console.WriteLine("-----------------");
            Console.WriteLine("Check balances");
            Console.WriteLine(bank.GetBalance(1));
            Console.WriteLine(bank.GetBalance(2));
            Console.WriteLine(bank.GetBalance(3));
            Console.WriteLine(bank.GetBalance(4));

            Console.WriteLine("-----------------");
            Console.WriteLine("Transfering money");
            Console.WriteLine("Happy Path");
            Console.WriteLine(bank.Transfer(1, 4, 50.50));
            Console.WriteLine("Unappy Path");
            Console.WriteLine(bank.Transfer(5, 4, 50.50));
            Console.WriteLine(bank.Transfer(1, 5, 50.50));
            Console.WriteLine("-----------------");
            Console.WriteLine("Check balances");
            Console.WriteLine(bank.GetBalance(1));
            Console.WriteLine(bank.GetBalance(2));
            Console.WriteLine(bank.GetBalance(3));
            Console.WriteLine(bank.GetBalance(4));

            Console.ReadKey();

        }
    }
}
