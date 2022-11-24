string path = @"X:\vs\git\lab\aktios\OS\os1\source.txt";

string str = "";
//str = Console.ReadLine();
str = File.ReadAllText(path);

double s;
s = Convert.ToDouble(str);

File.Delete(path);
string res = Convert.ToString(func1(s));
File.WriteAllText(path, res);

double func1(double s)
{
    return Math.Pow(s, 5);
}
