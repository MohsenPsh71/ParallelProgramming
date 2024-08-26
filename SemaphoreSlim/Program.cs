// See https://aka.ms/new-console-template for more information

var semaphore = new SemaphoreSlim(2, 10);
for (int i = 0; i < 20; i++)
{
    Task task = Task.Factory.StartNew(() => 
    {
        Console.WriteLine($"Enter task {Task.CurrentId}");
        semaphore.Wait();
        Console.WriteLine("Proccessing");
    });
}
while (semaphore.CurrentCount <= 2)
{
    Console.ReadKey();
    semaphore.Release(2);
}
