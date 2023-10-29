using System.Diagnostics;
class Program
{
    static void Main()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine("id:" + currentProcess.Id + " name:" + currentProcess.ProcessName);

        Process.Start("D:\\Git\\lab\\sem5\\sp\\6\\process4\\process2\\bin\\Debug\\net6.0\\process4.exe");
        Process.Start("D:\\Git\\lab\\sem5\\sp\\6\\process4\\process2\\bin\\Debug\\net6.0\\process4.exe");
        Process.Start("D:\\Git\\lab\\sem5\\sp\\6\\process4\\process2\\bin\\Debug\\net6.0\\process4.exe");
    }
}