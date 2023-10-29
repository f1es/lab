using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine("id:" + currentProcess.Id + " name:" + currentProcess.ProcessName);
        Process newProcess = Process.Start("notepad");
        Process.Start("D:\\Git\\lab\\sem5\\sp\\6\\process1\\process2\\bin\\Debug\\net6.0\\process1.exe");
        Process.Start("D:\\Git\\lab\\sem5\\sp\\6\\process11\\process2\\bin\\Debug\\net6.0\\process11.exe");
        //D:\\Git\\lab\\sem5\\sp\\4\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\net6.0\\ConsoleApp1.exe
        //Console.WriteLine("child process id:" + newProcess.Id + " child process name:" + newProcess.ProcessName);
        Thread.Sleep(3000);
        Console.WriteLine($"process {newProcess.ProcessName} with id {newProcess.Id} killed");
        newProcess.Kill();

        //foreach (Process process in Process.GetProcesses())
        //{
        //    Console.WriteLine($"id: {process.Id} name: {process.ProcessName}");
        //}
    }
}