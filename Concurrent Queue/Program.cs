using System.Collections.Concurrent;

//FIFO First in First Out
ConcurrentQueue<int> q = new ConcurrentQueue<int>();
q.Enqueue(1);
q.Enqueue(2);
q.Enqueue(3);

int resault;
if (q.TryDequeue(out resault))
{
    Console.WriteLine($"I Removed {resault}");
}
if (q.TryPeek(out resault))
{
    Console.WriteLine($"Last Item {resault}");
}