using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.HelperDefinitions
{
    public class AccountOwner
    {
        public string FirstName { get; set; }
        public AccountOwner(string firstName)
        {
            this.FirstName = firstName;
        }

        public void Notify(Account account, string message)
        {
            Console.WriteLine($"{this.FirstName} - {message}");
        }
    }

}
