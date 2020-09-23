using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class StrategyExample
    {
        public static void RunExample()
        {
            CheckingAccount checkingAccount = new CheckingAccount("Brian");
            checkingAccount.Deposit(100);
            checkingAccount.AccrueInterest(new ShortTermInterestStrategy());
        }
    }

    class ShortTermInterestStrategy : IInterestStrategy
    {
        public decimal CalculateInterest(decimal amount)
        {
            return amount * (decimal).001;
        }
    }

    class LongTermInterestStrategy : IInterestStrategy
    {
        public decimal CalculateInterest(decimal amount)
        {
            return amount * (decimal).01;
        }
    }
}
