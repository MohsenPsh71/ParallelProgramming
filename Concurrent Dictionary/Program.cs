using System.Collections.Concurrent;

internal class Program
{
    private static ConcurrentDictionary<string, string> Capitals = new ConcurrentDictionary<string, string>();
    public static void addcity()
    {
        bool Success = Capitals.TryAdd("iran", "tehran");
        string WitchTask = string.Empty;
        Task.Factory.StartNew(() =>
        {
            WitchTask = Task.CurrentId.HasValue ? $"Task {Task.CurrentId}" : "Main Thread";
        }).Wait();
        Console.WriteLine(WitchTask);
        Console.WriteLine(Success ? "Added" : "Not Added");
    }
    private static void Main(string[] args)
    {
        addcity();

        var s = Capitals.AddOrUpdate("france", "paris", (string k, string old) => old);
        Console.WriteLine(Capitals["france"]);

        string toremove = "france";
        string removed;
        var didremove = Capitals.TryRemove(toremove, out removed);
        Console.WriteLine(didremove ? $"{removed} is Removed" : "Not Removed");

        foreach (var item in Capitals)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }

}