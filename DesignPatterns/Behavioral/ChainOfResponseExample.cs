using DesignPatterns.Creational;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class ChainOfResponseExample
    {
        public static void RunExample()
        {
            Employee junior = new Junior("Laurel", "Anderson", null);
            Employee manager = new Manager("Brian", "Hoscheit", null);

            junior.SetSuccessor(manager);

            junior.Approve(1001);
        }
    }

}
