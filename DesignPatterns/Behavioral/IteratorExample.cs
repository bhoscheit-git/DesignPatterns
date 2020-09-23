using DesignPatterns.HelperDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class IteratorExample
    {
        public static void RunExample()
        {
            Iterator iterator = new Iterator(2);

            iterator[0] = new CheckingAccount("Brian");
            iterator[1] = new CheckingAccount("Laurel");

            while (!iterator.IsDone())
            {
                CheckingAccount checkingAccount = (CheckingAccount)iterator.GetNext();
            }
        }
    }
}
