using SimpleBanking.Model;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBanking
{
    class Bank
    {
        public string _name;
        List<Account> _accounts = new List<Account>();

        public Bank(string name)
        {
            _name = name;
        }

        public string Deposit(long accountNumber, double depositAmount)
        {
            if (accountNumber < 1 || depositAmount < 0.01)
            {
                return "Please provide a vaild account number or deposit amount greater than 0.";
            }
            
            var account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return $"Unable to find account with account number {account}";
            }

            account.Balance += depositAmount;
            return "You money was deposited successfully.";
        }

        public string Transfer(long transferFromAccountNumber, long transferToAccountNumber, double transferAmount)
        {
            if (transferFromAccountNumber < 1 || transferToAccountNumber < 1)
            {
                return "please enter a valid from or to account number.";
            }
            var transferFromAccount = GetAccountByAccountNumber(transferFromAccountNumber);
            var transferToAccount = GetAccountByAccountNumber(transferToAccountNumber);
            if (transferFromAccount == null)
            {
                return $"Unable to find account with account number {transferFromAccount}";
            }
            else if (transferToAccount == null)
            {
                return $"Unable to find account with account number {transferToAccount}";
            }

            if (transferFromAccount.Balance < transferAmount)
            {
                return "Insuficant funds.";
            }
            else
            {
                transferFromAccount.Balance -= transferAmount;
                transferToAccount.Balance += transferAmount;
                return "Account transfer complete";
            }
        }

        public string Withdraw(long accountNumber, double withdrawAmount)
        {
            if (accountNumber < 1 || withdrawAmount < 0.01)
            {
                return "Please provide a vaild account number or withdraw amount greater than 0.";
            }

            var account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return $"Unable to find account with account number {account}";
            }
            

            if (account.Balance > withdrawAmount)
            {
                if (account.AccountType == AccountTypes.InvestmentIndividual && withdrawAmount > 500)
                {
                    return "Indivdual investment accounts are unable to witdraw more than 500.";
                }
                account.Balance -= withdrawAmount;
                return "Money successfully withdrew.";
            }
            else
            {
                return "Insuficant funds.";
            }
        }

        public string GetBalance(long accountNumber)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return $"Unable to find account with account number {account}";
            }

            return $"Your current account balance is {account.Balance}";
        }

        public string AddAccount(string firstName, string lastName, AccountTypes accountTypes)
        {
            if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return "Accounts needs to have both a first name and a last name.";
            }

            var accountNumber = _accounts.Count + 1;
            _accounts.Add(new Account()
            {
                FirstName = firstName,
                LastName = lastName,
                AccountType = accountTypes,
                Balance = 0,
                AccountNumber = accountNumber
            });
            return $"Account was sccessfully created for {lastName} with an account number of {accountNumber}";
        }

        private Account GetAccountByAccountNumber(long accountNumber)
        {
            try
            {
                return _accounts.Single(x => x.AccountNumber == accountNumber);
            }
            catch
            {
                return null;
            }
            
        }


    }
}
