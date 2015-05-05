using System;
using System.Threading;

namespace Kunto.ConsoleClient.Threads
{
    public class UsingThreadPool
    {
        public void StartThreadInThreadPool()
        {
            ThreadPool.QueueUserWorkItem(
                (s) =>
                {
                    Console.WriteLine("This text is written by thread from the thread pool.");
                });

            Console.ReadKey();
        }
    }
}
