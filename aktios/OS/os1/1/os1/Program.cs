double a, b, c;
a = double.Parse(args[0]);
b = double.Parse(args[1]);
c = double.Parse(args[2]);

string res = Convert.ToString(func1(a, b, c));
Console.WriteLine(res);

double func1(double a, double b, double c)
{
    return a / b * Math.Sqrt(c);
}
