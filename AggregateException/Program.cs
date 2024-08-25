// See https://aka.ms/new-console-template for more information

static void methode()
{
    var t = Task.Factory.StartNew(() =>
    {
        throw new DivideByZeroException();
        //throw new AccessViolationException();
    });
    try
    {
        t.Wait();
    }
    catch (AggregateException Aggregate)
    {
        foreach (var item in Aggregate.InnerExceptions)
        {
            Console.WriteLine($"Exception {item.GetType()}");
        }

    }
}
methode();