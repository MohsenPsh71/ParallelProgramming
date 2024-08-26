// See https://aka.ms/new-console-template for more information
static void Method()
{
    //ContinueWith
    var task = Task.Factory.StartNew(() =>
    {
        Console.WriteLine($"First Step {Task.CurrentId}");
    });
    var task2 = task.ContinueWith(t =>
    {
        Console.WriteLine($"Final Step {Task.CurrentId} {t.Status}");
        if (t.IsFaulted)
        {
            throw t.Exception.InnerException;
        }
    });
    try
    {
        task2.Wait();
    }
    catch (AggregateException ae)
    {

        ae.Handle(e =>
        {
            Console.WriteLine("Excrption" + e);
            return true;
        });
    }
}
static void Method2()
{
    //ContinueWith
    var task = Task.Factory.StartNew(() => "Task 1");
    var task2 = Task.Factory.StartNew(() => "Task 2");
    var task3 = Task.Factory.ContinueWhenAll([task, task2], tasks =>
    {
        Console.WriteLine("Tasks completed");
        foreach (var item in tasks)
        {
            Console.WriteLine($"\t{item.Status}");
            Console.WriteLine($"\t{item.Result}");
        }
    });
    try
    {
        task3.Wait();
    }
    catch (AggregateException ae)
    {

        ae.Handle(e =>
        {
            Console.WriteLine("Excrption" + e);
            return true;
        });
    }
}
//Method();
Method2();
