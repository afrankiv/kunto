using System;
using System.Threading.Tasks;

namespace Kunto.ConsoleClient.TestThreads
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
            Task<int> task = Task.Run(() => { return 42; });
            Console.WriteLine(task.Result);
        }

        public void StartGenericTasksAndContinueWith()
        {
            Task<int> task = Task.Run(
                () =>
                {
                    return 42;
                }).ContinueWith(
                (handledTask) =>
                {
                    return handledTask.Result * 2;
                });
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

            task.ContinueWith((i) => Console.WriteLine("Canceled"), TaskContinuationOptions.OnlyOnCanceled);
            
            task.ContinueWith((i) => Console.WriteLine("Faulted"), TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task.ContinueWith((i) => Console.WriteLine("Completed"), TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
    }
}
