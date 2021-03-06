    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace TaskYieldExample
    {
        class Program
        {
            private static CancellationTokenSource CancellationTokenSource;
            static void Main(string[] args)
            {
                SelfCancellingAsync();
                SelfCancellingAsync();
                SelfCancellingAsync();
                Console.ReadLine();
            }
            private static async void SelfCancellingAsync()
            {
                Console.WriteLine("SelfCancellingAsync starting.");
                var cts = new CancellationTokenSource();
                var oldCts = Interlocked.Exchange(ref CancellationTokenSource, cts);
                if (oldCts != null)
                {
                    oldCts.Cancel();
                }
                // Allow quick cancellation.
                await Task.Yield();
                if (cts.IsCancellationRequested)
                {
                    return;
                }
                // Do the "meaty" work.
                Console.WriteLine("Performing intensive work.");
                var answer = await Task
                    .Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith(_ => 42, TaskContinuationOptions.ExecuteSynchronously);
                if (cts.IsCancellationRequested)
                {
                    return;
                }
                // Do something with the result.
                Console.WriteLine("SelfCancellingAsync completed. Answer: {0}.", answer);
            }
        }
    }
