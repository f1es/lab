
//Console.WriteLine("Hello, World!");
string path = @"X:\vs\git\lab\aktios\OS\os1\source.txt";

string str;
//str = Console.ReadLine();
str = File.ReadAllText(path);
var str2 = str.Split(' ');

double a, b, c;
a = Convert.ToDouble(str2[0]);
b = Convert.ToDouble(str2[1]);
c = Convert.ToDouble(str2[2]);

File.Delete(path);

string res = Convert.ToString(func1(a, b, c));
File.WriteAllText(path, res);

double func1(double a, double b, double c)
{
    return a / b * Math.Sqrt(c);
}
