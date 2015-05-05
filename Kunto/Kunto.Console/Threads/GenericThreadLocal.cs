using System;
using System.Threading;

namespace Kunto.ConsoleClient.Threads
{
    public class GenericThreadLocal
    {
        /// <summary>
        /// If you want to use local data in a thread and initialize it for each thread, 
        /// you can use the ThreadLocal<T> class. This class takes a delegate to a method that initializes the value.
        /// </summary>
        private static ThreadLocal<int> _field = new ThreadLocal<int>(
            () =>
            {
                return Thread.CurrentThread.ManagedThreadId;

            });

        public void ShareClassFieldBetweenThreadsUsinfThreadLocal()
        {
            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("First thread: {0}", i);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Second thread: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
