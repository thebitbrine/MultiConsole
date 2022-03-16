# MultiConsole
Now you can have as many as you want



### The Why
------
```
For the longest time, I wanted to be able to output to multiple consoles
from one app so it is easier to focus on the output that I need from that
debugging session without going around the code turning Console.WriteLines on and off.

I have looked around for such a library for years now but it does not exist.
probably because either everyone just codes the way they're "supposed" to without
trying to pull off some wild shit or they're too busy working for some big corp.
It is just more efficient to see what you need. You know what's not efficient?
the code. It pulls off too many wild shit and the reason why it is half a meg
is because it has the shitty icon file (used for host consoles) as a string.
```

### The How
```
It is complicated.
Not really. It basically runs timeout.exe with /T -1 /NOBREAK so it waits for [Ctrl + C]
waits for 666 ms so the timeout.exe host has time to boot up.
(Why not just AllocConsole() you ask? because whenever the lib calls FreeConsole() to flip
to another console the first console closes cuz there's nothing attached to it.
So to bypass that "feature" we need to hijacks something else's console so it
stays open when the lib is busy outputting to another console.)
So yeah, it hijacks its console, clears it up, sets the title, the icon,
cancel key event and exit events, disables the quick edit mode (AKA misclick-to-pause-the-whole-damn-app),
and keeps the host console's PID in a dictionary attached to its name.

whenever you call anything* console related it flips the attached 
console to the specified one using the PID from aforementioned
dictionary and calls the underlying function.
```

### The Why Not
```
Do not use this in prod. It WILL fuck up. also, it is not thread-safe because
it can't switch consoles as fast and also it calls kernel32.dll functions, you know how that usually goes.
Also, you can't use ConsoleCancelEventHandler because I used them all to kill
all the other consoles when shit hits the fan (or the app exits)
Memory management? Who's that?
```

### Limitations
```
Many.
+ No multi-threading (if you're not like me)
+ No direct ConsoleCancelEventHandler event access
+ Slow console host boot-up time (666 ms each)
+ Unsafe code
+ .NetCore 3.1
just to name a few.
```


### Usage example
```cs
using Console = MultiConsole.Console; //Just to make things easier

namespace MultiConsoleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.QuickEdit = true; //default is false, and also no. you can't flip it at runtime.

            for (int i = 0; i < 10000; i++)
            {
                //To get the console host going you'll have to run a function, anything will work
                //Just keep that in mind so you don't scroll through all the windows like a maniac
                //when in reality there is no console because your code hasn't been called yet

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
```

