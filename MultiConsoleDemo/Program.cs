using System;
using System.Threading;
using MultiConsole;
using Console = MultiConsole.Console;

namespace MultiConsoleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Hello to console 1", "Console #1");
                Console.Beep(222, 500, "Console #1");

                Console.WriteLine("Hello to console 2", "Console #2");
                Console.Beep(333, 500, "Console #2");

                Console.WriteLine("Hello to console 3", "Console #3");
                Console.Beep(444, 500, "Console #3");
            }

        }
    }
}
