using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public static class AbstractFactoryExample
    {
        public static void RunExample()
        {
            ShortTermAccountFactory shortTermAccountFactory = new ShortTermAccountFactory();
            AbstractAccountFactory abstractAccountFactory = new AbstractAccountFactory(shortTermAccountFactory, "Brian");

            BankAccount checkingAccount = abstractAccountFactory.BankAccount;
            InvestmentAccount investmentAccount = abstractAccountFactory.InvestmentAccount;

            checkingAccount.Deposit(100);
            investmentAccount.Deposit(100);
        }
    }


    class AbstractAccountFactory
    {
        private BankAccount _bankAccount;
        private InvestmentAccount _investmentAccount;
        public AbstractAccountFactory(IConcreteAccountFactory concreteAccountFactory, string accountOwner)
        {
            this._bankAccount = concreteAccountFactory.CreateBankAccount(accountOwner);
            this._investmentAccount = concreteAccountFactory.CreateInvestmentAccount(accountOwner);
        }

        public BankAccount BankAccount {
            get { return _bankAccount; }
        }
        public InvestmentAccount InvestmentAccount
        {
            get { return _investmentAccount; }
        }

    }
    interface IConcreteAccountFactory
    {
        BankAccount CreateBankAccount(string accountOwner);
        InvestmentAccount CreateInvestmentAccount(string accountOwner);
    }
    class ShortTermAccountFactory : IConcreteAccountFactory
    {
        public BankAccount CreateBankAccount(string accountOwner)
        {
            return new CheckingAccount(accountOwner);
        }

        public InvestmentAccount CreateInvestmentAccount(string accountOwner)
        {
            return new TaxableAccount(accountOwner);
        }
    }

    class LongTermAccountFactory : IConcreteAccountFactory
    {
        public BankAccount CreateBankAccount(string accountOwner)
        {
            return new SavingAccount(accountOwner);
        }

        public InvestmentAccount CreateInvestmentAccount(string accountOwner)
        {
            return new RetirementAccount(accountOwner);
        }
    }
}
