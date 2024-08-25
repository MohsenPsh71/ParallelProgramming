// See https://aka.ms/new-console-template for more information
static double Methode1(int count)
{
    double a = 0;
    for (int i = 0; i < count; i++)
    {
        a += Math.Pow(0.2, 0.5);
    }
    return a;
}

Console.WriteLine("Start");

//use task with Methode & Task.Factory
Task<double> task1 = Task.Factory.StartNew(() => Methode1(100));
Console.WriteLine(task1.Result);

//use task with Lambda & Task.Factory
Task<double> task2 = Task.Factory.StartNew(() =>{

    double a = 0;
    for (int i = 0; i < 100; i++)
    {
        a += Math.Pow(0.2, 0.5);
    }
    return a;
});
Console.WriteLine(task2.Result);

//use task with Methode & new Task
Task<double> task3 = new Task<double>(() => Methode1(100));
task3.Start();
Console.WriteLine(task3.Result);

Console.WriteLine("End");