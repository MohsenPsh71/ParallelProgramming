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
//Method();
