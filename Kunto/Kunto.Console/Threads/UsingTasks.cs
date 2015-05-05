using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kunto.ConsoleClient.Threads
{
    /// <summary>
    /// Executing a Task on another thread makes sense only if you want to keep the user interface thread
    /// free for other work or if you want to parallelize your work on to multiple processors.
    /// </summary>
    public class UsingTasks
    {
        /// <summary>
        /// This example creates a new Task and immediately starts it. 
        /// Calling Wait is equivalent to calling Join on a thread. 
        /// It waits till the Task is finished before exiting the application.
        /// </summary>
        public void StartTask()
        {
            Task task = Task.Run(
                () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine('*');
                    }
                });

            task.Wait();
        }

        public void StartGenericTasks()
        {
            Task<int> task = Task.Run(() => 42);
            Console.WriteLine(task.Result);
        }

        public void StartGenericTasksAndContinueWith()
        {
            Task<int> task = Task.Run(() => 42).ContinueWith(handledTask => handledTask.Result * 2);
            Console.WriteLine(task.Result);
        }

        /// <summary>
        /// The ContinueWith method has a couple of overloads that you can use to configure when the continuation will run. 
        /// This way you can add different continuation methods that will run when an exception happens, 
        /// the Task is canceled, or the Task completes successfully.
        /// </summary>
        public void StartGenericTaskInDiffModes()
        {
            Task<int> task = Task.Run(() => 42);

            task.ContinueWith(i => Console.WriteLine("Canceled"), TaskContinuationOptions.OnlyOnCanceled);

            task.ContinueWith(i => Console.WriteLine("Faulted"), TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task.ContinueWith(i => Console.WriteLine("Completed"), TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }

        /// <summary>
        /// A TaskFactory is created with a certain configuration and can then be used to create Tasks with that configuration.
        /// </summary>
        public void StartTasksUsingFactory()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                var taskFactory = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                taskFactory.StartNew(() => results[0] = 0);
                taskFactory.StartNew(() => results[1] = 1);
                taskFactory.StartNew(() => results[2] = 2);

                return results;
            });

            var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                {
                    Console.WriteLine(i);
                }
            });

            finalTask.Wait();
        }

        /// <summary>
        /// Use the method WaitAll to wait for multiple Tasks to finish before continuing execution.
        /// </summary>
        public void StartMultipleTasksAndWaitAll()
        {
            Console.WriteLine("Test Start!");
            var tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });
            
            Task.WaitAll(tasks);
            Console.WriteLine("Test End!");
        }
    }
}
