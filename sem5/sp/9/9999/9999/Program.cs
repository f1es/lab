using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        programSemaphore p1 = new();
        Thread.Sleep(2000);
        programMutex p2 = new();
    }

    public static void ZeroToThousand()
    {
        for (int i = 0; i <= 1000; i++)
        {
            Console.WriteLine(i);
        }
    }
    public static void ThousandTo2Thousand()
    {
        for (int i = 1000; i <= 2000; i++)
        {
            Console.WriteLine(i);
        }
    }
}

class programMutex
{
    Thread thread1 = new Thread(() => ZeroToThousand());
    Thread thread2 = new Thread(() => ThousandTo2Thousand());
    static Mutex mutex = new Mutex();
    
    public programMutex()
    {
        Console.WriteLine("Mutex");
        thread1.Start();
        Thread.Sleep(10);
        thread2.Start();
    }
    public static void ZeroToThousand()
    {
        mutex.WaitOne();

        for (int i = 0; i <= 1000; i++)
        {
            Console.WriteLine(i);
        }

        mutex.ReleaseMutex();
    }
    public static void ThousandTo2Thousand()
    {
        mutex.WaitOne();

        for (int i = 1000; i <= 2000; i++)
        {
            Console.WriteLine(i);
        }

        mutex.ReleaseMutex();
    }
}

class programSemaphore
{
    Thread thread1 = new Thread(() => ZeroToThousand());
    Thread thread2 = new Thread(() => ThousandTo2Thousand());
    static Semaphore semaphore = new(1, 2);

    public programSemaphore()
    {
        Console.WriteLine("Semaphore");
        thread1.Start();
        Thread.Sleep(10);
        thread2.Start();
    }
    public static void ZeroToThousand()
    {
        semaphore.WaitOne();

        for (int i = 0; i <= 1000; i++)
        {
            Console.WriteLine(i);
        }

        semaphore.Release();
    }
    public static void ThousandTo2Thousand()
    {
        semaphore.WaitOne();

        for (int i = 1000; i <= 2000; i++)
        {
            Console.WriteLine(i);
        }

        semaphore.Release();
    }
}

class program3
{
    Thread thread1 = new Thread(() => Program.ZeroToThousand());
    Thread thread2 = new Thread(() => Program.ThousandTo2Thousand());

    public void Use()
    {
        thread1.Start();
        thread2.Start();
    }
}