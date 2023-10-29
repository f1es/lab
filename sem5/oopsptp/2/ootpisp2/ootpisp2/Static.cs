using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ootpisp2
{
    public static class Static
    {
        public static int classCounter = 0;
        public static bool InRange(int min,  int max, int a)
        {
            if (a >= min && a <= max) 
                return true;
            else
                return false;
        }

    }
}
