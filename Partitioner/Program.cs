// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;

List<int> source = Enumerable.Range(0, 100).ToList();
OrderablePartitioner<Tuple<int,int>> rangepartitioner = Partitioner.Create(0, source.Count);
// faster than for and foreach in bigdata
double[] nums = new double[source.Count];
Parallel.ForEach(rangepartitioner, (range, state) =>
{
    for (int i = range.Item1; i < range.Item2; i++)
        nums[i] = source[i]*Math.PI;
});
foreach (int i in nums) Console.WriteLine(i);