using DesignPatterns.Creational;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class MediatorExample
    {
        public static void RunExample()
        {
            Mediator mediator = new Mediator();
            Employee employee1 = new Manager("Brian", "Hoscheit", mediator);
            Employee employee2 = new Manager("Laurel", "Anderson", mediator);

            mediator.Employee1 = employee1;
            mediator.Employee2 = employee2;

            employee1.SendMessage("Hi, how are you?");
            employee2.SendMessage("Doing well, and you?");

        }


    }
}
