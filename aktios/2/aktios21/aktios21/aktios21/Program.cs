
string path = @"X:\OS\source.txt";

string[] str = File.ReadAllLines(path);

double S = 0;
double a = Convert.ToDouble(str[0]), b = Convert.ToDouble(str[1]), c = Convert.ToDouble(str[2]);

//a = Convert.ToDouble(Console.ReadLine());
//b = Convert.ToDouble(Console.ReadLine());
//c = Convert.ToDouble(Console.ReadLine());

Console.WriteLine(helloworld(a, b, c));

Console.WriteLine(function1(helloworld(a, b, c)));

double helloworld(double a, double b, double c)
{
    return a / (b * Math.Sqrt(c) );
}


double function1(double S)
{
    return Math.Pow(S, 5);
}