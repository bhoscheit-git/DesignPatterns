﻿using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.OtherLearning;
using DesignPatterns.Structural;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creational
            AbstractFactoryExample.RunExample();
            FactoryExample.RunExample();
            SingletonExample.RunExample();

            // Structural
            CompositeExample.RunExample();
            FacadeExample.RunExample();
            ProxyExample.RunExample();

            // Behavioral
            AdapterExample.RunExample();
            ChainOfResponseExample.RunExample();
            IteratorExample.RunExample();
            MediatorExample.RunExample();
            ObserverExample.RunExample();
            StrategyExample.RunExample();



            var delegateAndEvents = new DelegateAndEventExample();
            delegateAndEvents.RunDelegateExample();
            delegateAndEvents.RunEventExample();



            Console.ReadKey(true);
        }
    }
}
