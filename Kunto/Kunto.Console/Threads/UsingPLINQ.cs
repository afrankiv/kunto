using System;
using System.Collections.Generic;
using System.Linq;

namespace Kunto.ConsoleClient.Threads
{
    public class UsingPLINQ
    {
        /// <summary>
        /// 
        /// </summary>
        public void DisplayDigitsParallel()
        {
            IEnumerable<int> numbers = Enumerable.Range(0, 10);
            int[] parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// If you want to ensure that the results are ordered, you can add the AsOrdered operator. 
        /// Your query is still processed in parallel, but the results are buffered and sorted.
        /// </summary>
        public void DisplayDigitsParallelAsOrder()
        {
            IEnumerable<int> numbers = Enumerable.Range(0, 10);
            int[] parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 != 0).ToArray();

            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// When using PLINQ, you can use the ForAll operator to iterate over a collection
        /// when the iteration can also be done in a parallel way.
        /// </summary>
        public void UseForAll()
        {
            IEnumerable<int> numbers = Enumerable.Range(0, 20);

            ParallelQuery<int> parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));
        }

        /// <summary>
        /// The .NET Framework handles this by aggregating all exceptions into one AggregateException. 
        /// This exception exposes a list of all exceptions that have happened during parallel execution.
        /// </summary>
        public void TestAggregatedExceptions()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel().Where(i => isEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }

        private static bool isEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }

}
