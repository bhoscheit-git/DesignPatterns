using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public static class ChainOfResponseExample
    {
        public static void RunExample()
        {
            Employee junior = new Junior("Laurel");
            Employee manager = new Manager("Brian");

            junior.Successor = manager;

            junior.Approve(1001);
        }
    }

    abstract class Employee
    {
        public Employee Successor { get; set; }
        public string Name { get; set; }
        public Employee(string name)
        {
            this.Name = name;
        }
        public abstract void Approve(decimal amount);
    }

    class Junior : Employee
    {
        public Junior(string name) : base(name) { }
        public override void Approve(decimal amount)
        {
            if (amount < 1000)
            {
                Console.WriteLine($"Approved by {this.Name} - {amount}");
            }
            else
            {
                if (this.Successor != null)
                {
                    this.Successor.Approve(amount);
                }    
            }
        }
    }

    class Manager : Employee
    {
        public Manager(string name) : base(name) { }
        public override void Approve(decimal amount)
        {
            if (amount < 10000)
            {
                Console.WriteLine($"Approved by {this.Name} - {amount}");
            }
            else
            {
                if (this.Successor != null)
                {
                    this.Successor.Approve(amount);
                }
            }
        }
    }
}
