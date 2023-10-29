
using System.Data.Common;

class Program
{
    static Mutex mutex = new Mutex();
    static void Main()
    {
        Array2 a = new Array2(2 ,4);
        
        Console.WriteLine();

        Thread thread1 = new Thread(() => a.Transpose());
        Thread thread2 = new Thread(() => a.RowsSum());

        a.Output();
        
        thread1.Start();
        mutex.WaitOne();
        thread2.Start();
        Thread.Sleep(10);
        a.Output();
    }
}

class Array2
{
    //Mutex mutex = new Mutex();

    int[,] matrix;
    int rows = 0;
    int colums = 0;

    public int[,] Matrix { get => matrix; set => matrix = value; }

    public Array2(int _rows, int _colums)
    {
        rows = _rows;
        colums = _colums;
        Matrix = new int[rows, colums];
        RandomFill();
    }

    public Array2()
    {
        rows = 0;
        colums = 0;
    }

    public int[,] Transpose()
    {
        int[,] transpMatrix = new int[colums, rows];

        for (int i = 0; i < rows; i ++)
            for (int j = 0; j < colums; j++)
            {
                transpMatrix[j,i] = Matrix[i,j];
                //Console.WriteLine("transp");
            }

        int temp = 0;
        temp = rows;
        rows = colums;
        colums = temp;

        Matrix = transpMatrix;

        Console.WriteLine("Transpose");
        mutex.WaitOne();
        return transpMatrix;
    }

    public void RandomFill()
    {
        for (int i = 0;i < rows; i ++)
            for (int j = 0;j < colums; j ++)
            {
                Matrix[i,j] = new Random().Next(10);
            }
    }

    public void Output()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                Console.Write(Matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void RowsSum()
    {

        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for(int j = 0;j < colums; j++)
            {
                rowSum += Matrix[i,j];
                //Console.WriteLine("rwsum");
            }
            Console.WriteLine(rowSum);
        }

        Console.WriteLine("RowSum");
    }
}