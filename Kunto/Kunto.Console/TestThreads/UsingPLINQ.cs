using System;
using System.Linq;

namespace Kunto.ConsoleClient.TestThreads
{
    public class UsingPLINQ
    {
        /// <summary>
        /// 
        /// </summary>
        public void DisplayDigitsParallel()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult){
                Console.WriteLine(i);
            }
        }
        
        /// <summary>
        /// If you want to ensure that the results are ordered, you can add the AsOrdered operator. 
        /// Your query is still processed in parallel, but the results are buffered and sorted.
        /// </summary>
        public void DisplayDigitsParallelAsOrder()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 != 0).ToArray();

            foreach (int i in parallelResult){
                Console.WriteLine(i);
            }
        }
    }
}
