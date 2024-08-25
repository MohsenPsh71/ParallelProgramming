// See https://aka.ms/new-console-template for more information

static void Method1()
{
    //w8 for specific time to receive signal and cancel
    var cancellation_Token_Source = new CancellationTokenSource();
    var token = cancellation_Token_Source.Token;

    var t = new Task(() =>
    {
        Console.WriteLine("\tstart task");
        bool canceled = token.WaitHandle.WaitOne(5000);
        Console.WriteLine(canceled ? "canceled" : "not canceled");
        Console.WriteLine("\tEnd task");
    }, token);
    t.Start();


    Console.ReadLine();
    cancellation_Token_Source.Cancel();
}

static void Method2()
{
    //w8 for signal to cancel
    var cancellation_Token_Source = new CancellationTokenSource();
    var token = cancellation_Token_Source.Token;

    token.Register(() =>
    {
        Console.WriteLine("Cancellation requested");
    });

    var t = new Task(() =>
    {
        int i = 0;
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"{i++}");
        }
    }, token);
    t.Start();


    Console.ReadLine();
    cancellation_Token_Source.Cancel();
    Console.WriteLine("task is canceled");

}


static void Method3()
{
    // use several CancellationTokenSource for better performance 
    var planned = new CancellationTokenSource();
    var emergency = new CancellationTokenSource();
    var emergency2 = new CancellationTokenSource();

    var linked_cancellations = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, emergency.Token, emergency2.Token);

    linked_cancellations.Token.Register(() => Console.WriteLine("cancellation requested"));

    var t = new Task(() =>
    {
        int i = 0;
        while (true)
        {
            linked_cancellations.Token.ThrowIfCancellationRequested();
            Console.WriteLine($"{i++}");
            Thread.Sleep(100);
        }
    }, linked_cancellations.Token);
    t.Start();

    Console.ReadLine();
    emergency2.Cancel();
    Console.WriteLine("task is canceled");

}

Console.WriteLine("Start Main");
Method1();
//Method2();
//Method3();
Console.WriteLine("End Main");
