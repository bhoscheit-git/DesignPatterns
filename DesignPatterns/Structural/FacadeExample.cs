using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural
{
    public static class FacadeExample
    {
        public static void RunExample()
        {
            Account fromAccount = new CheckingAccount("Brian");
            Account toAccount = new TaxableAccount("Brian");

            fromAccount.Deposit(100);

            BankingTransferFacade bankingTransferFacade = new BankingTransferFacade(fromAccount, toAccount);

            bankingTransferFacade.Transfer(100);
        }
    }

    class BankingTransferFacade
    {
        public Account FromAccount { get; protected set; }
        public Account ToAccount { get; protected set; }

        public BankingTransferFacade(Account fromAccount, Account toAccount)
        {
            this.FromAccount = fromAccount;
            this.ToAccount = toAccount;
        }

        public void Transfer(decimal amount)
        {
            this.FromAccount.Withdrawl(amount);
            this.ToAccount.Withdrawl(amount);
        }
    }
}
