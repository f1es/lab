using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Stopwatch Stopwatch = new();
    static void Main(string[] args)
    {
        Stopwatch.Start();
        ZeroToThousand();
        ThousandTo2Thousand();
        Stopwatch.Stop();
        Console.WriteLine("\nSimple");
        Console.WriteLine(Stopwatch.Elapsed.TotalSeconds);
        Console.ReadKey();
    }

    public static void ZeroToThousand()
    {
        for (int i = 0; i <= 1000; i++)
        {
            Console.Write(i + " ");
        }
    }
    public static void ThousandTo2Thousand()
    {
        for (int i = 1000; i <= 2000; i++)
        {
            Console.Write(i + " ");
        }
    }
}
