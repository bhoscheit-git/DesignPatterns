using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural
{
    public static class AdapterExample
    {
        public static void RunExample()
        {
            Target target = new AdapterClass();
            target.MakeRequest();
        }

        public class Target
        {
            public virtual void MakeRequest()
            {
                Console.WriteLine("Regular request made.");
            }
        }

        public class AdapterClass : Target
        {
            private AdapteeClass _adapteeClass = new AdapteeClass();

            public override void MakeRequest()
            {
                this._adapteeClass.MakeRequest();
            }
        }

        public class AdapteeClass
        {
            public void MakeRequest()
            {
                Console.WriteLine("Adaptee request");
            }
        }
    }
}
