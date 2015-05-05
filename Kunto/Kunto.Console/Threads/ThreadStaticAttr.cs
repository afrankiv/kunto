using System;
using System.Threading;

namespace Kunto.ConsoleClient.Threads
{
    /// <summary>
    /// A thread can also have its own data that’s not a local variable. 
    /// By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field.
    /// </summary>
    public class ThreadStaticAttr
    {
        /// <summary>
        /// With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. 
        /// If you remove it, you can see that both threads access the same value and it becomes 20.
        /// </summary>
        [ThreadStatic]
        private static int _field;

        public void ShareClassFieldBetweenThreadsUsingThreadStatic()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("First thread: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Second thread: {0}", _field);
                }
            }).Start();
        }
    }
}
