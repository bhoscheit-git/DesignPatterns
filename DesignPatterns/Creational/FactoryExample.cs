using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public static class FactoryExample
    {
        public static void RunExample()
        {
            AccountFactory accountFactory = new AccountFactory();
            Account checkingAccount = accountFactory.CreateAccount(AccountType.Checking, "Brian");
            Account savingAccount = accountFactory.CreateAccount(AccountType.Saving, "Brian");

            for (int i = 0; i <= 6; i++)
            {
                checkingAccount.Withdrawl(1);
                savingAccount.Withdrawl(1);
            }
    
        }
    }

    interface IAccountFactory
    {
        Account CreateAccount(AccountType accountType, string accountOwner);
    }
    class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(AccountType accountType, string accountOwner)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    return new CheckingAccount(accountOwner);
                case AccountType.Saving:
                    return new SavingAccount(accountOwner);
                default:
                    throw new NotImplementedException();
            }
        }
    }

    
}
