
class Program
{
    static Barrier barrier = new Barrier(2, b =>
    {
        Console.WriteLine($"\t{b.CurrentPhaseNumber} finished");
    });

    public static void Method1()
    {
        Console.WriteLine("step 1");
        barrier.SignalAndWait();
        Thread.Sleep(2000);
        Console.WriteLine("step 3");
        barrier.SignalAndWait();
        Thread.Sleep(2000);
        Console.WriteLine("step 5");
    }

    public static void Method2()
    {
        Console.WriteLine("step 2");
        barrier.SignalAndWait();
        Thread.Sleep(2000);
        Console.WriteLine("step 4");
        barrier.SignalAndWait();
        Thread.Sleep(2000);
        Console.WriteLine("step 6");
    }

    static void Main(string[] args)
    {
        var task1 = Task.Factory.StartNew(Method1);
        var task2 = Task.Factory.StartNew(Method2);


        var task3 = Task.Factory.ContinueWhenAll(new[] { task1, task2 }, tasks =>
        {
            Console.WriteLine("all tasks finished");
        });
        Console.ReadLine();
    }
}

