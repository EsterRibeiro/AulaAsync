﻿using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(DoSomething);
            thread.Start();
            Console.WriteLine("Hello World!");
            
        }

        private static void DoSomething()
        {
            Thread.Sleep(5000);
        }
    }
}
