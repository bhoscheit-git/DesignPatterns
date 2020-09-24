using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.OtherLearning
{
    public delegate int CalculationPerformedHandler(int num1, int num2);
    public class DelegateAndEventExample
    {

        public void RunDelegateExample()
        {
            var addDel = new CalculationPerformedHandler(Add);
            var subtractDel = new CalculationPerformedHandler(Subtract);
            var multiplyDel = new CalculationPerformedHandler(Multiply);
            var divideDel = new CalculationPerformedHandler(Divide);

            Console.WriteLine($"Add {addDel?.Invoke(2, 2)}");
            Console.WriteLine($"Substract {subtractDel?.Invoke(2, 2)}");
            Console.WriteLine($"Multiply {multiplyDel?.Invoke(2, 2)}");
            Console.WriteLine($"Divide {divideDel?.Invoke(2, 2)}");

            Console.WriteLine($"Calculate Add {Calculate(addDel, 2, 2)}");

        }

        public void RunEventExample()
        {
            WorkerBee workerBee = new WorkerBee();
            workerBee.WorkPerformed += WorkPerformed;
            // workerBee.WorkComplete += WorkCompleted;
            // Anon delegate
            workerBee.WorkComplete += delegate(object sender, WorkPerformedEventArgs e) { Console.WriteLine("Complete!"); };
            
            workerBee.DoWork(5);

            
        }

        private void WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Performed!");
        }

        private void WorkCompleted(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Completed!");
        }

        private void CalculationPerformed()
        {
            Console.WriteLine("The calculation was performed!");
        }

        public int Add(int num1, int num2) => num1 + num2;
        public int Subtract(int num1, int num2) => num1 + num2;
        public int Multiply(int num1, int num2) => num1 + num2;
        public int Divide(int num1, int num2) => num1 + num2;
        public int Calculate(CalculationPerformedHandler del, int num1, int num2)
        {
            if (del != null)
            {
                return del(num1, num2);
            }
            else
            {
                throw new ApplicationException();
            }
        }

    }

    
    public class WorkPerformedEventArgs : EventArgs
    {
        public int Hours { get; set; }
    }

    public class WorkerBee
    {
        public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
        public event WorkPerformedHandler WorkPerformed;
        // You can use an event without a delegate using the below
        public event EventHandler<WorkPerformedEventArgs> WorkComplete;

        public void DoWork(int hours)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i);
            }
            OnWorkComplete(hours);
        }
        protected virtual void OnWorkPerformed(int hours)
        {
            var del = WorkPerformed;
            del?.Invoke(this, new WorkPerformedEventArgs { Hours = hours });
        }

        protected virtual void OnWorkComplete(int hours)
        {
            var del = WorkComplete;
            del.Invoke(this, new WorkPerformedEventArgs { Hours = hours });
        }


    }


}
