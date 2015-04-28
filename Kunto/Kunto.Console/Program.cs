using System;
using System.Threading;

using Kunto.ConsoleClient.TestThreads;

namespace Kunto.ConsoleClient
{
    public static class Program
    {
        public static void Main()
        {
            // stratThreadInMain();
            //Console.WriteLine("1. Testing shared class field between threads.");
            //new ThreadStaticAttr().ShareClassFieldBetweenThreadsUsingThreadStatic();

            //Console.WriteLine("2. Testing shared class field between threads.");
            //new GenericThreadLocal().ShareClassFieldBetweenThreadsUsinfThreadLocal();

            //new UsingThreadPool().StartThreadInThreadPool();
            //new UsingTasks().StartTask();
            // new UsingTasks().StartTasksUsingFactory();
            //new UsingTasks().StartMultipleTasksAndWaitAll();

            //var content = new UsingAsyncAwait().GetHtmlFromWebSite("http://www.microsoft.com/").Result;
            //Console.WriteLine(content);

            new UsingPLINQ().DisplayDigitsParallelAsOrder();
        }

        private static void stratThreadInMain()
        {
            var thread = new Thread(new ThreadStart(startOtherThread));
            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread do some work", i);
                Thread.Sleep(0);
            }

            thread.Join();
        }

        private static void startOtherThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
