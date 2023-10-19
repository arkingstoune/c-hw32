using System.Data.Common;
using System.Threading;
CancellationTokenSource cts = new();
cts.Token.Register(() => Console.WriteLine("cancelation Requsted"));
const int sometime = 3000; 
SomeMethod();
Console.WriteLine("please press a number 1 if you want to work with CancellationToken and 0 to continue without breaking");
int a = int.Parse(Console.ReadLine());
//______________
Sleep sleep = await Sleepingasync();//...........
Work work = await Workingasync();//..............
//we have created two method that works not at the same time


GettingRestasync();
WakingUpasync(cts.Token);
//we have created two method that works at the same time 


//______________
async Task SomeMethod()// method works not in the main thread
{
}


//_______________
if(a == 1) cts.Cancel();//changing token data
//_______________
async Task<Sleep> Sleepingasync()//  we have created async method
{
    Console.WriteLine("sleeping...");
    await Task.Delay(sometime);// Task.Delay makes async method wait some time 
    return new();
}
async Task<Work> Workingasync()
{
    Console.WriteLine("Working...");
    await Task.Delay(sometime);
    return new();
}
async Task<Rest> GettingRestasync()
{
    Console.WriteLine("Getting rest...");
    await Task.Delay(sometime);
    return new();
}
async Task<Wake> WakingUpasync(CancellationToken token)
{
    try // creating try catch 
    {
        //token.ThrowIfCancellationRequested();
        if(token.IsCancellationRequested)
            throw new OperationCanceledException();// throwing new execption
        Console.WriteLine("waking up...");
        await Task.Delay(sometime);
    }
    catch//(System.Exception except)
    {
        //Console.WriteLine(except);
        Console.WriteLine("it doesnt work properly :(");
    }
    return new();
}
class Sleep{}
class Work{}
class Rest{}
class Wake {}