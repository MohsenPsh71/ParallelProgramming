// See https://aka.ms/new-console-template for more information

using System.Collections;

int count = 20;
int[] items = Enumerable.Range(0, count).ToArray();

//items.AsParallel().ForAll<int>(a => Console.WriteLine(a));

ParallelQuery<int> items2 = items.AsParallel().AsOrdered().Select(a => a).Where(a => a>=10);
foreach (int item in items2)
{
    Console.WriteLine(item);
}
