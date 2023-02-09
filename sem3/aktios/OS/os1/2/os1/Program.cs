string path = @"X:\vs\git\lab\aktios\OS\os1\source.txt";

string str = "";
//str = Console.ReadLine();

var s = Convert.ToDouble(Console.ReadLine());
File.Delete(path);
string res = Convert.ToString(func1(s));
File.AppendAllText(path, res);
Console.WriteLine(res);
double func1(double s)
{
    return Math.Pow(s, 5);
}
