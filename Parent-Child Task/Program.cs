


    class Program
    {

        static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                Console.WriteLine("Parent task start");


                var child = new Task(() =>
                {
                    Console.WriteLine("\tChild task start");
                    //throw new AccessViolationException();
                    Console.WriteLine("\tChild task End");
                }, TaskCreationOptions.AttachedToParent);

                var failed = child.ContinueWith(t =>
                {
                    Console.WriteLine($"child task failed {t.Status}");


                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

                var complete = child.ContinueWith(t =>
                {
                    Console.WriteLine($"child task completed {t.Status}");

                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                child.Start();

                Console.WriteLine("Parent task End");
            });

            parent.Start();

            try
            {
                parent.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => true);
            }

            Console.ReadLine();
        }
    }

