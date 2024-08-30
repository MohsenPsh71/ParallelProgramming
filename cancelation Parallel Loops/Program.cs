// See https://aka.ms/new-console-template for more information
static void Method()
{
    CancellationTokenSource Cancellation = new CancellationTokenSource();
    ParallelOptions parallelOptions = new ParallelOptions { CancellationToken = Cancellation.Token };
    ParallelLoopResult ParallelLoop = Parallel.For(0, 100, parallelOptions, (int a, ParallelLoopState state) =>
    {
        Console.WriteLine($"Current ID {Task.CurrentId}");
        if (a == 10)
        {
            // if use this code you will have OperationCanceledException
            Cancellation.Cancel();
            //

            // if use this code you will have ParallelLoop.IsCompleted = false
            //state.Stop();
            //

            // if use this code you will have multiple IsExceptional and one AggregateException
            //throw new Exception();
            //
        }
        if(state.IsExceptional) {
            Console.WriteLine("IsExceptional");
        }
    });
    Console.WriteLine($"\n {ParallelLoop.IsCompleted}");
}

try
{
    Method();
}
catch (OperationCanceledException)
{
    Console.WriteLine("OperationCanceledException");
}
catch (AggregateException ae)
{
    ae.Handle(a => 
    {
        Console.WriteLine("AggregateException");
        Console.WriteLine(a.Message);
        return true;
    });
}
