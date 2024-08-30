// See https://aka.ms/new-console-template for more information

int count = 20;
int[] items = Enumerable.Range(0, count).ToArray();

//FullyBuffered (W8 to all proccess end)
ParallelQuery<int> items2 = items.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered).Select(a => a);

//NotBuffered you can see live when every proccess ended
//ParallelQuery<int> items2 = items.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered).Select(a => a);

foreach (int item in items2)
{
    Console.WriteLine(item);
}