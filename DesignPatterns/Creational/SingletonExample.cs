using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public static class SingletonExample
    {
        public static void RunExample()
        {
            Singleton singleton1 = Singleton.Instance();
            Singleton singleton2 = Singleton.Instance();
        }
    }

    class Singleton
    {
        private static Singleton _initialize;
        protected Singleton()
        {

        }

        public static Singleton Instance()
        {
            if (_initialize == null)
            {
                _initialize = new Singleton();
            }
            return _initialize;
        }
    }
}
