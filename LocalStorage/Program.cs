// See https://aka.ms/new-console-template for more information

int sum = 0;
//Parallel.For(0,1001,a => {
//    Interlocked.Add(ref sum,a);
//});

// this code faster & have better performance
Parallel.For(0, 1001,() =>0,(a,state,b) =>
{
    b += a;
    //if (a == 1) {
    //    state.Stop(); 
    //}
    return b;
}, finall =>
{
    Interlocked.Add(ref sum, finall);
});



Console.WriteLine(sum);

