using System;

namespace Kunto.ConsoleClient.DelegatesAndEvents
{
    public class DelegatesSample
    {
        private delegate int Calculate(int x, int y);

        private delegate void Del();

        /// <summary>
        /// Add two integers.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Multiply two integers.
        /// NOTE: Delegates can be nested in other types and they can then be used as a nested type.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// Demonstrates delegates usage.
        /// </summary>
        public void UseDelegate()
        {
            Calculate calc = this.Add;
            Console.WriteLine("Delegate adds '3' + '6' = " + calc(3, 6));


            calc = this.Multiply;
            Console.WriteLine("Delegate multiplies '3' * '6' = " + calc(3, 6));
        }

        public void MethodOne()
        {
            Console.WriteLine("Calling first method!!!");
        }

        public void MethodTwo()
        {
            Console.WriteLine("Calling second method!!!");
        }


        /// <summary>
        /// This is called multicasting. You can use the + or += operator to add 
        /// another method to the invocation list of an existing delegate instance.
        /// </summary>
        public void UseMulticatingDelegates()
        {
            Del del = this.MethodOne;
            del += this.MethodTwo;

            del();
        }
    }
}
