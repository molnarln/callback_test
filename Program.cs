using System;
using System.Linq;

namespace callback_test
{
    class Program
    {
        public delegate void CallbackDelegate(string input);

        static void Main(string[] args)
        {
            Test();
            CallbackDelegate cd = DoSomething;
            cd("xxxxxxxxx");

            Action<string> x = delegate (string valami) { Console.WriteLine(valami); };
            //local function-al is lehet:
            void y(string valami) { Console.WriteLine(valami); }
            DoWork(x);
            DoWork(y);
        }

        //fontos: ha az Action<string> helyett CallbackDelegate-et írunk a függvényben, és a Main-ben a DoWork(cd)-ként hívjuk meg, akkor is működni fog. Ha 
        // a jelenlegi állapot szerint tennénk be a DoWork(cd)-t, akkor nem működik, mert a delegate-et nem tudja átalakítani Action<string> type-á.
        public static void DoWork(Action<string> callback)
        {
            callback("Valami.");
        }

        public static void Test()
        {
            DoWork((input) => Console.WriteLine(input));
        }

        public static void DoSomething(string input)
        {
            Console.WriteLine(input);
        }
    }
}
