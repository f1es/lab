using System.Diagnostics;



class Program

{

    static void Main(string[] args)

    {

        List<Process> processes = new List<Process>();

        int[] fork = { 0, 1, 1, 2, 4, 4, 4 };

        int exec = 6;



        int parentPid = Process.GetCurrentProcess().Id;

        processes.Add(Process.GetProcessById(parentPid));



        Console.WriteLine($"MainProcess ID(1) {parentPid}");



        for (int i = 1; i < fork.Length; i++)

            processes.Add(CreateChild(i, processes[fork[i] - 1].Id, fork[i], exec));



        Process CreateChild(int chCount, int parentID, int parentCount, int exec)

        {

            Process chProc = new Process();

            chProc.StartInfo.FileName = "ls";

            chProc.StartInfo.Arguments = "";

            if (chCount != exec)

                chProc.StartInfo.RedirectStandardOutput = true;

            chProc.Start();

            chProc.WaitForExit();



            Console.WriteLine($"Process ID({++chCount}): {chProc.Id}. Parent ID({parentCount}): {parentID}.");

            return chProc;

        }

    }

}