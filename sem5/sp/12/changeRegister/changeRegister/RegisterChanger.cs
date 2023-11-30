using System.Text.RegularExpressions;

namespace changeRegister
{
    public static class Register
    {
        static int registerDifference = ('a') - ('A');
        public static string ToLowerReg(string inputString)
        {
            Regex upperRegexEng = new Regex(@"[A-ZА-Я]");
            string outputString = "";
            foreach (char c in inputString)
            {
                if (upperRegexEng.IsMatch(c.ToString()))
                    outputString += (char)(c + registerDifference);
                else
                    outputString += c;
            }
            return outputString;
        }

        public static string ToUpperReg(string inputString)
        {
            Regex upperRegex = new Regex(@"[a-zа-я]");
            string outputString = "";
            foreach (char c in inputString)
            {
                if (upperRegex.IsMatch(c.ToString()))
                    outputString += (char)(c - registerDifference);
                else
                    outputString += c;
            }
            return outputString;
        }
    }
}