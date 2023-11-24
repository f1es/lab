using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading;
class Program
{

    static void Main(string[] args)
    {
        lockObject p2 = new();
    }
}

class lockObject
{ 

    static Stopwatch sw = new Stopwatch();

    Thread thread1 = new Thread(() => ZeroToThousand());
    Thread thread2 = new Thread(() => ThousandTo2Thousand());
    static bool isLock = false;
    public lockObject()
    {
        Console.WriteLine("Variable");
        sw.Start();
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        sw.Stop();
        Console.WriteLine("\nVariable");
        Console.WriteLine(sw.Elapsed.TotalSeconds);
        Console.ReadKey();
    }
    public static void ZeroToThousand()
    {
        isLock = true;
        for (int i = 0; i <= 1000; i++)
        {
            Console.Write(i + " ");
        }
        isLock = false;
    }
    public static void ThousandTo2Thousand()
    {
        while (isLock) { }

        for (int i = 1000; i <= 2000; i++)
        {
            Console.Write(i + " ");
        }
    }
}
