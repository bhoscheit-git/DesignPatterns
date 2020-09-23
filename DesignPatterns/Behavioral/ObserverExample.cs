using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class ObserverExample
    {
        public static void RunExample()
        {
            Account account = new BankAccount("Brian");
            account.AddAccountOwner(new AccountOwner("Laurel"));

            account.Deposit(100);
            account.NotifyAccountOwners("Deposit has been made");
        }
    }


}
