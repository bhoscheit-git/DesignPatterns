using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural
{
    public static class ProxyExample
    {
        public static void RunExample()
        {
            Account account = new CheckingAccount("Brian");
            AccountProxy accountProxy = new AccountProxy(account);
            accountProxy.Deposit(100);
        }
    }

    class AccountProxy
    {
        private Account _account;

        public AccountProxy(Account account)
        {
            this._account = account;
        }

        public void Deposit(decimal amount)
        {
            Console.WriteLine("Proxy deposit");
            this._account.Deposit(amount);
        }
    }
}
