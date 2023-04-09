using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class CorrectInput
    {
        public static bool IsOnlyLetters(string str)
        {
            if (str == "") return false;
            if (str == " ") return false;

            foreach (char c in str)
            {
                if (Char.IsNumber(c)) return false;
                if (c == '-') return false;
                if (c == '.') return false;
                if (c == ',') return false;
                if (c == ';') return false;
                if (c == '/') return false;
                if (c == ':') return false;
                if (c == '@') return false;
                if (c == '#') return false;
                if (c == '$') return false;
                if (c == '%') return false;
                if (c == '^') return false;
                if (c == '&') return false;
                if (c == '*') return false;
            }
            return true;
        }

        public static bool InRange(int leftRange, int rightRange, int number)
        {
            if (number >= leftRange && number <= rightRange) return true;
            return false;
        }
    }
}
