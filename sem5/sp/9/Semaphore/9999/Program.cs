using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Stopwatch sw = new();
    static void Main(string[] args)
    {
        programSemaphore p1 = new();
        Console.ReadKey();
    }
}

class programSemaphore
{
    static Stopwatch sw = new();

    Thread thread1 = new Thread(() => ZeroToThousand());
    Thread thread2 = new Thread(() => ThousandTo2Thousand());
    static Semaphore semaphore = new(1, 2);


    public programSemaphore()
    {
        Console.WriteLine("Semaphore");
        thread1.Start();
        Thread.Sleep(1);
        thread2.Start();
    }
    public static void ZeroToThousand()
    {
        sw.Start();

        semaphore.WaitOne();
        for (int i = 0; i <= 1000; i++)
            Console.Write(i + " ");
        semaphore.Release();
    }
    public static void ThousandTo2Thousand()
    {
        semaphore.WaitOne();
        for (int i = 1000; i <= 2000; i++)
            Console.Write(i + " ");
        semaphore.Release();

        sw.Stop();
        Console.WriteLine("\nSemaphore");
        Console.WriteLine(sw.Elapsed.TotalSeconds);
    }
}
