using System.Collections.Concurrent;

//Add & Read random
ConcurrentBag<int> bag = new ConcurrentBag<int>();
var tasks = new List<Task>();

for (int i = 0; i < 10; i++)
{
    var input = i;
    tasks.Add(Task.Factory.StartNew(() =>
    {
        bag.Add(input);
        Console.WriteLine($"{Task.CurrentId} has added {input}");
        int resault;
        if (bag.TryPeek(out resault))
        {
            Console.WriteLine($"{Task.CurrentId} has picked {input}");
        }
    }));
}
Task.WaitAll(tasks.ToArray());

int last;
if (bag.TryTake(out last))
{
    Console.WriteLine( $"\n\n\n last item is {last}");
}
