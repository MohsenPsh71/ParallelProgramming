
class Program
{
    private static int taskCount = 5;
    static CountdownEvent countdown = new CountdownEvent(taskCount);
    static void Main(string[] args)
    {
        var tasks = new Task[taskCount];
        for (int i = 0; i < taskCount; i++)
        {
            tasks[i] = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Start task {Task.CurrentId}");
                Thread.Sleep(2000);
                countdown.Signal();
                Console.WriteLine("End task");
            });
        }


        var finalTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Enter final task");
            countdown.Wait();
            Console.WriteLine("All tasks finished");
        });

        finalTask.Wait();
        Console.ReadLine();
    }
}

