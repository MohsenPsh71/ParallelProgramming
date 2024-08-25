// See https://aka.ms/new-console-template for more information

static void methode()
{
    var t = Task.Factory.StartNew(() =>
    {
        throw new DivideByZeroException();
        //throw new AccessViolationException();
    });
    var t2 = Task.Factory.StartNew(() =>
    {
        throw new AccessViolationException();
    });
    var t3 = Task.Factory.StartNew(() =>
    {
        throw new AbandonedMutexException();
    });
    try
    {
       Task.WaitAll(t,t2,t3);
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