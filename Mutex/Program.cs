// See https://aka.ms/new-console-template for more information

var tasks = new List<Task>();
BankAccount Bank_Account = new BankAccount();
Mutex mutex = new Mutex();
Mutex mutex2 = new Mutex();

for (int r = 0; r < 10; r++)
{

    tasks.Add(Task.Factory.StartNew(() =>
    {
        bool Have_Lock = mutex.WaitOne();
        try
        {
            for (int i = 0; i < 1000; i++)
            {
                Bank_Account.Deposite(100);
            }
        }
        finally
        {
            if (Have_Lock) mutex.ReleaseMutex();
        }

    }));

    tasks.Add(Task.Factory.StartNew(() =>
    {
        bool Have_Lock = mutex2.WaitOne();
        try
        {
            for (int i = 0; i < 1000; i++)
            {
                Bank_Account.Withtow(100);
            }
        }
        finally
        {
            if (Have_Lock) mutex2.ReleaseMutex();
        }

    }));

    tasks.Add(Task.Factory.StartNew(() =>
    {
        bool Have_Lock = WaitHandle.WaitAll([mutex, mutex2]);
        try
        {
                Bank_Account.final();
        }
        finally
        {
            if (Have_Lock)
            {
                mutex.ReleaseMutex();
                mutex2.ReleaseMutex();
            }
        }

    }));

}

Task.WaitAll(tasks.ToArray());
Console.WriteLine(Bank_Account.Balance);




class BankAccount
{
    public int Balance { get; set; }
    object _lock = new object();
    public void Deposite(int amount)
    {
        lock (_lock)
        {
            Balance += amount;
        }
    }
    public void Withtow(int amount)
    {
        lock (_lock)
        {
            Balance -= amount;
        }
    }
    public void final()
    {
        Deposite(1000);
        Withtow(100);
    }


}
