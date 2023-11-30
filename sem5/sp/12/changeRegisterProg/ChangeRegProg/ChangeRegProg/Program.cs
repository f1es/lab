using System.Text.RegularExpressions;
//using System.Windows;
//using System.Windows.Forms;
using System.Windows;
using changeRegister;
class Program
{
    [STAThread]
    public static void Main()
    { 
        Console.WriteLine((int)('a') - (int)('A'));
        //Console.WriteLine((int)('A'));
        //Clipboard.SetData(DataFormats.Text, (Object)"123");

        //string pattern = @"[a-z]";
        //Regex upperRegex = new Regex(@"[A-Z]");
        //string inputString = "AbCGSGRSGt";
        //string neww = "";
        //foreach (char c in inputString)
        //{
        //    if (upperRegex.IsMatch(c.ToString()))
        //        neww += (char)((int)c + (int)('a') - (int)('A'));
        //    else
        //        neww += c;
        //}
        string str = "ABHAFIBBfbiyфафаШПИКГЫИгкыпышгпПРИВЕТприветI43--+++gwm~~1!#%!^5BYFAifey";
        Console.WriteLine(Register.ToLowerReg(str));
        Console.WriteLine(Register.ToUpperReg(str));
    }
}