using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Kunto.ConsoleClient.Threads
{
    public class UsingConcurrentCollections
    {
        /// <summary>
        /// One Task listens for new items being added to the collection. 
        /// It blocks if there are no items available. The other Task adds items to the collection.
        /// </summary>
        public void TestBlockingcollection()
        {
            BlockingCollection<string> collection = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(collection.Take());
                }
            });

            Task writeTask = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    collection.Add(s);
                }
            });

            writeTask.Wait();
        }

        public void TestConccurentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }

            }).Wait();
        }
    }
}
