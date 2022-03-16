using System;
using Console = MultiConsole.Console; //Just to make things easier

namespace MultiConsoleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.QuickEdit = true; //default is false, and also no. you can't flip it at runtime.


            for (int i = 0; i < 666; i++)
            {
                Console.WriteLine($"Is {i+1} consoles enough yet?", i.ToString());
            }


            for (int i = 0; i < 131313; i++)
            {
                //To get the console host going you'll have to run a function, anything will work
                //Just keep that in mind so you don't scroll through all the windows like a maniac
                //when in reality there is not console because your code hasn't been called yet

                Console.WriteLine("Hello to console 1", "You can name your consoles anything you want.");
                Console.Beep(222, 500, "You can name your consoles anything you want.");

                Console.WriteLine("Hello to console 2", "🔥");
                Console.Beep(333, 500, "🔥");

                Console.WriteLine("Hello to console 3", "Console #3");
                Console.Beep(444, 500, "Console #3");

            }
        }
    }
}
