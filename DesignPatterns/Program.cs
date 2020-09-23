﻿using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
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
            ChainOfResponseExample.RunExample();
            IteratorExample.RunExample();
            ObserverExample.RunExample();
            StrategyExample.RunExample();


            



            Console.ReadKey(true);
        }
    }
}
