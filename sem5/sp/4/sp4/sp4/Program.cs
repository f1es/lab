using sp4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static Mutex mutex = new Mutex(); // Мьютекс для синхронизации доступа к общим данным
    static int threadCount = 0; // Счетчик активных потоков
    static int count = 0;
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[] directories = {
            "E:\\PSU\\5_semestr\\SP\\lab_4\\directories\\1",
            "E:\\PSU\\5_semestr\\SP\\lab_4\\directories\\2",
            "E:\\PSU\\5_semestr\\SP\\lab_4\\directories\\3",
            "E:\\PSU\\5_semestr\\SP\\lab_4\\directories\\4"
        }; // Пример списка каталогов

        int maxThreads = directories.Length / 2; // Количество потоков в два раза меньше каталогов

        foreach (string directory in directories)
        {
            if (threadCount < maxThreads)
            {
                Thread thread = new Thread(() => SearchFiles(directory));
                thread.Name = $"поток №{directory[^1]}";
                thread.Start();
                Interlocked.Increment(ref threadCount);
                //threadCount++;
            }
            else
            {
                SearchFiles(directory);
            }
        }

        while (threadCount > 0)
        {
            // Ожидание завершения всех потоков
        }

        Console.WriteLine("Поиск завершен.");
        Console.ReadLine();
        Console.WriteLine("count = " + count);
    }

    static void SearchFiles(string directory)
    {
        mutex.WaitOne(); // Блокировка мьютекса

        //Console.WriteLine("Поиск файлов в каталоге: " + directory);

        mutex.ReleaseMutex(); // Разблокировка мьютекса

        string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
        count++;
        foreach (string file in files)
        {
            string contents = File.ReadAllText(file);
            Console.WriteLine(Thread.CurrentThread.Name);
            if (contents.Contains("Text")) // Здесь указывается текст, который нужно найти в файлах
            {
                //Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Найден файл: {file}");
                //Console.BackgroundColor = default;
            }
        }

        mutex.WaitOne(); // Блокировка мьютекса

        //Console.WriteLine("Поиск в каталоге " + directory + " завершен.");

        mutex.ReleaseMutex(); // Разблокировка мьютекса

        Interlocked.Decrement(ref threadCount); // Уменьшение счетчика активных потоков

        //threadCount--;
    }
}