﻿// See https://aka.ms/new-console-template for more information

static void Method3()
{
    var planned = new CancellationTokenSource();
    var emergency = new CancellationTokenSource();
    var emergency2 = new CancellationTokenSource();

    var linked_cancellations = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, emergency.Token, emergency2.Token);


    var t = new Task(() =>
    {
        Console.WriteLine("task 1 Start");
        for (int i = 0; i < 3; i++)
        {
            emergency2.Token.ThrowIfCancellationRequested();
            Console.WriteLine($"in task 1 - {i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("task 1 end");
    }, emergency2.Token);
    t.Start();

    var t2 = new Task(() =>
    {
        Console.WriteLine("task 2 Start");
        for (int i = 0; i < 10; i++)
        {
            planned.Token.ThrowIfCancellationRequested();
            Console.WriteLine($"in task 2 - {i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("task 2 end");
    }, planned.Token);
    t2.Start(); 

    Task.WaitAll(t, t2);
    Console.WriteLine("Next Commands");

    Console.ReadLine();
    emergency2.Cancel();
    planned.Cancel();
    Console.WriteLine("task is canceled");

}

Console.WriteLine("Start Main");

Method3();

Console.WriteLine("End Main");