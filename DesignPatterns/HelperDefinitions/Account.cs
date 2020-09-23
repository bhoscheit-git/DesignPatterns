using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.HelperDefinitions
{
    public enum AccountType
    {
        Checking,
        Saving
    }

    public abstract class Account
    {
        public decimal AccountBalance { get; protected set; }
        public string AccountOwner { get; protected set; }
        public int WithdrawlCount { get; protected set; }

        private List<AccountOwner> _accountOwners;

        public Account(string accountOwner)
        {
            this._accountOwners = new List<AccountOwner>();
            this.AddAccountOwner(new AccountOwner(accountOwner));
        }

        public void AddAccountOwner(AccountOwner accountOwner)
        {
            this._accountOwners.Add(accountOwner);
        }

        public void RemoveAccountOwner(AccountOwner accountOwner)
        {
            this._accountOwners.Add(accountOwner);
        }

        public void NotifyAccountOwners(string message)
        {
            foreach (AccountOwner accountOwner in this._accountOwners)
                accountOwner.Notify(this, message);
        }

        public virtual void Deposit(decimal amount) => this.AccountBalance += amount;
        public virtual void Withdrawl(decimal amount) => this.AccountBalance -= amount;
        public virtual void AccrueInterest(IInterestStrategy interestStrategy)
        {
            this.AccountBalance += interestStrategy.CalculateInterest(this.AccountBalance);
        }
    }

    public class BankAccount : Account
    {
        public BankAccount(string accountOwner) : base(accountOwner) { }
    }

    public class InvestmentAccount : Account
    {
        public InvestmentAccount(string accountOwner) : base(accountOwner) { }
    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountOwner) : base(accountOwner) { }
    }

    public class SavingAccount : BankAccount
    {
        public SavingAccount(string accountOwner) : base(accountOwner) { }

        public override void Withdrawl(decimal amount)
        {
            if (this.WithdrawlCount >= 6)
            {
                Console.WriteLine("Exceeded number of withdrawls.");
            }
            {
                base.Withdrawl(amount);
                this.WithdrawlCount++;
            }

        }
    }

    public class TaxableAccount : InvestmentAccount
    {
        public TaxableAccount(string accountOwner) : base(accountOwner) { }
    }

    public class RetirementAccount : InvestmentAccount
    {
        public RetirementAccount(string accountOwner) : base(accountOwner) { }
    }

    public interface IInterestStrategy
    {
        decimal CalculateInterest(decimal amount);
    }


}
