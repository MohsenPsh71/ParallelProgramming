// See https://aka.ms/new-console-template for more information

static IEnumerable<int> Range(int start, int end, int step)
{
    for (int i = start; i < end; i++) yield return i;
}



Console.WriteLine("\nInvoke-----------------\n");

var task1 = new Action(() =>
{
    Console.WriteLine($"First {Task.CurrentId}");
});
var task2 = new Action(() =>
{
    Console.WriteLine($"Second {Task.CurrentId}");
});

var task3 = new Action(() =>
{
    Console.WriteLine($"third {Task.CurrentId}");
});

Parallel.Invoke(task1,task2, task3);

//-------------------------------------

Console.WriteLine("\nFor-----------------\n");

Parallel.For(1, 21, a =>
{
    Console.WriteLine( $"Mohsen {a}");
});

//---------------------------------------
Console.WriteLine("\nForEach-----------------\n");
int[] myarray = new int[20];
Parallel.ForEach(Range(0, 20, 1), a =>
{
    myarray[a] = 20;
});

//---------------------------------------
Console.WriteLine("\nForEach 2-----------------\n");

List<string> Persons = new List<string>()
{
    "ali",
    "rex",
    "daboo",
    "Doom",
    "Sara",
};
Parallel.ForEach(Persons, p => {  Console.WriteLine(p); });

//---------------------------------------
Console.WriteLine("\nForEach With ParallelOptions-----------------\n");
string[] strs = { "I", "am", "Mohsen", "Pourvand" };
var po = new ParallelOptions()
{
    MaxDegreeOfParallelism = 1,
};
Parallel.ForEach(strs, po, str =>
{
    Console.WriteLine(str);
});