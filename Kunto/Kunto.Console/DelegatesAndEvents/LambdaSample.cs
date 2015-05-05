using System;

namespace Kunto.ConsoleClient.DelegatesAndEvents
{
    /// <summary>
    /// Lambda expressions are the preferred way to go when writing new code.
    /// </summary>
    public class LambdaSample
    {
        private delegate int Calculate(int x, int y);

        public void SimpleLambda()
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(5, 2));

            calc = (x, y) => x * y;
            Console.WriteLine(calc(5, 2));
        }

        /// <summary>
        /// If you want a delegate type that doesn’t return a value, you can use the System.Action types.
        /// </summary>
        public void UseActionDelegate()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            calc(2, 9);
        }

        /// <summary>
        /// The Func types can be found in the System namespace and they represent
        /// delegates that return a type and take 0 to 16 parameters.
        /// </summary>
        public void UseFunctionDelegate()
        {
            Func<int, int, int> calc = (x, y) =>
            {
                return x * y;
            };

            Console.WriteLine(calc(4, 3));
        }
    }
}
