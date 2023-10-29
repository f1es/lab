using System.Diagnostics;
class Program
{
    static void Main()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine("id:" + currentProcess.Id + " name:" + currentProcess.ProcessName);
    }
}