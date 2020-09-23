using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public abstract class Employee
    {
        private static int _currentId;
        protected Mediator mediator;
        public int EmployeeId { get; protected set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        public Employee Successor { get; protected set; }

        static Employee()
        {
            _currentId = 0;
        }
        public Employee(string firstName, string lastName, Mediator mediator)
        {
            this.EmployeeId = this.GetNextId();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.mediator = mediator;
        }

        public int GetNextId() => ++_currentId;
        public void SetSuccessor(Employee successor) => this.Successor = successor;

        public abstract void Approve(decimal amount);

        public virtual void ReceiveMessage(string message, Employee fromEmployee)
        {
            Console.WriteLine($"Employee {this.FirstName} {this.LastName} received message from {fromEmployee.FirstName} {fromEmployee.LastName}");
            Console.WriteLine(message);
        }

        public virtual void SendMessage(string message)
        {
            this.mediator.SendMessage(message, this);
        }

        public virtual void Notify(string message, Employee fromEmployee)
        {
            Console.WriteLine($"Message to {this.FirstName} {this.LastName}");
            Console.WriteLine($"Message from {fromEmployee.FirstName} {fromEmployee.LastName}");
            Console.WriteLine(message);
        }
    }

    public class Mediator
    {
        public Employee Employee1 { get; set; }
        public Employee Employee2 { get; set; }

        public void SendMessage(string message, Employee employee)
        {
            if (Employee1.EmployeeId == employee.EmployeeId)
            {
                Employee2.Notify(message, this.Employee1);
            }
            else
            {
                Employee1.Notify(message, this.Employee2);
            }
        }
    }

    


    public class Junior : Employee
    {
        public Junior(string firstName, string lastName, Mediator mediator) 
            : base(firstName, lastName, mediator) 
        { 
        
        }

        public override void Approve(decimal amount)
        {
            if (amount < 10000)
            {
                Console.WriteLine($"Junior {this.FirstName} {this.LastName} approved {amount}");
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

    public class Manager : Employee
    {
        public Manager(string firstName, string lastName, Mediator mediator)
            : base(firstName, lastName, mediator)
        {

        }

        public override void Approve(decimal amount)
        {
            if (amount < 10000)
            {
                Console.WriteLine($"Junior {this.FirstName} {this.LastName} approved {amount}");
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
