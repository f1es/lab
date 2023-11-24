using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Stopwatch sw = new();
    static Thread thread1 = new Thread(() => ZeroToThousand(isOutput));
    static Thread thread2 = new Thread(() => ThousandTo2Thousand(isOutput));
    static Mutex mutex = new Mutex();
    static bool isOutput = true;
    static void Main(string[] args)
    {
        if (args.Length == 1)
            if (args[0] == "n")
                isOutput = false;

        Console.WriteLine("Mutex");
        thread1.Start();
        Thread.Sleep(1);
        thread2.Start();
        Console.ReadKey();
    }
    public static void ZeroToThousand(bool output)
    {
        sw.Start();
        mutex.WaitOne();

        for (int i = 0; i <= 1000; i++)
        {
            if (isOutput) Console.Write(i + " ");
        }

        mutex.ReleaseMutex();
    }
    public static void ThousandTo2Thousand(bool output)
    {
        mutex.WaitOne();

        for (int i = 1000; i <= 2000; i++)
        {
            if (isOutput) Console.Write(i + " ");
        }

        mutex.ReleaseMutex();
        sw.Stop();
        Console.WriteLine("\nMutex");
        Console.WriteLine(sw.Elapsed.TotalSeconds);
    }
}