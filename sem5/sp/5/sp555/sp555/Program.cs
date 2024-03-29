﻿class Program
{
    static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    static void Main(string[] args)
    {
 
        Thread thread1 = new Thread(() => ZeroToNine());
        Thread thread2 = new Thread(() => TenToTweny());
        thread1.Start();
        thread2.Start();
        Console.ReadKey();


    }
    static void ZeroToNine()
    {

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        manualResetEvent.Set();
    }

    static void TenToTweny()
    {
        manualResetEvent.WaitOne();
        for (int i = 10; i <= 20; i++)
        {
            Console.WriteLine(i);
        }
    }

}
