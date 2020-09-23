using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural
{
    public static class CompositeExample
    {
        public static void RunExample()
        {
            AccountComposite accountRoot = new AccountComposite("Brian");
            AccountComposite accountTree1 = new AccountComposite("Diana");
            AccountComposite accountTree2 = new AccountComposite("Mark");
            AccountComposite accountLeaf1 = new AccountComposite("This");
            AccountComposite accountLeaf2 = new AccountComposite("Is");
            AccountComposite accountLeaf3 = new AccountComposite("It");

            accountRoot.Add(accountTree1);
            accountRoot.Add(accountTree2);

            accountTree2.Add(accountLeaf1);
            accountTree2.Add(accountLeaf2);
            accountTree2.Add(accountLeaf3);


            accountRoot.Notify(1);


        }
    }


    interface IAccountComponent
    {
        void Add(AccountComposite account);
        void Remove(AccountComposite account);
        void Notify(int depth);
    }
    class AccountComposite : IAccountComponent
    {
        private List<IAccountComponent> _accounts;
        public string Name { get; set; }
        public AccountComposite(string name)
        {
            this._accounts = new List<IAccountComponent>();
            this.Name = name;
        }

        public void Add(AccountComposite account)
        {
            this._accounts.Add(account);
        }

        public void Notify(int depth)
        {
            Console.WriteLine($"{depth} - {this.Name}");
            foreach (IAccountComponent account in this._accounts)
                account.Notify(depth + 1);
        }

        public void Remove(AccountComposite account)
        {
            this._accounts.Remove(account);
        }
    }
}
