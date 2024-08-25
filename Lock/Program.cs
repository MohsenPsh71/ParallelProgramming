// See https://aka.ms/new-console-template for more information

var tasks = new List<Task>();
BankAccount Bank_Account = new BankAccount();
for (int r = 0; r<1000; r++) {

    tasks.Add(Task.Factory.StartNew(() => {
        for (int i = 0; i < 1000; i++)
        {
            Bank_Account.Deposite(100);
        }
    }));

    tasks.Add(Task.Factory.StartNew(() => {
        for (int j = 0; j < 1000; j++)
        {
            Bank_Account.Withtow(100);
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

}
    