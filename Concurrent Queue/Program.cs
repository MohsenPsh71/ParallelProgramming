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

//LIFO Last in First Out
ConcurrentStack<int> ints = new ConcurrentStack<int>();
ints.Push(1);
ints.Push(2);
ints.Push(3);
ints.Push(4);
ints.Push(5);

int resault2;
if (ints.TryPop(out resault2))
{
    Console.WriteLine($"I Removed {resault2}");
}
if (ints.TryPeek(out resault2))
{
    Console.WriteLine($"Last Item {resault2}");
}

var items = new int[3];
if (ints.TryPopRange(items,0,3)>0)
{
    var text = string.Join(" , ",items.Select(i => i.ToString()));
    Console.WriteLine($"Deleted Items {text}");
}

