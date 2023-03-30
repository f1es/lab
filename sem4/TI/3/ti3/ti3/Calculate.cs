using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti3
{
    class Calculate
    {
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public int ToInt(char charNumber)
        {
            return charNumber - '0';
        }

        public char ToChar(int intNumber)
        {
            int temp = intNumber + '0';
            return (char)temp;
        }

        public int Sum(string firstNumber, string secondNumber)
        {
            while(firstNumber.Length < secondNumber.Length)
            {
                string temp = "";
                temp = "0" + firstNumber; 
                firstNumber = temp;
            }

            while (secondNumber.Length < firstNumber.Length)
            {
                string temp = "";
                temp = "0" + secondNumber;
                secondNumber = temp;
            }

            int result = 0;
            firstNumber = Reverse(firstNumber);
            secondNumber = Reverse(secondNumber);
            for (int i = 0; i < firstNumber.Length; i++)
            {
                result += (ToInt(firstNumber[i]) + ToInt(secondNumber[i])) * (Int32)Math.Pow(10,i);
            }

            return result;
        }

        public int Multiple(string firstNumber, string secondNumber)
        {
            int result = 0;
            firstNumber = Reverse(firstNumber);
            secondNumber = Reverse(secondNumber);

            for (int i = 0; i < firstNumber.Length; i++)
            {
                for(int j = 0; j < secondNumber.Length; j++)
                {
                    result += ToInt(firstNumber[i]) * ToInt(secondNumber[j]) * (Int32)Math.Pow(10, i) * (Int32)Math.Pow(10, j);
                }
            }

            return result;
        }

        public string Divide(string firstNumber, string secondNumber)
        {
            string result = "";

            string dividend = "0"; 
            int divider = 0;
            string remainder = "";

            for(int i = 0; i <= firstNumber.Length - 1; i++)
            {
                
                for(int j = 0; int.Parse(dividend) < int.Parse(secondNumber); j++) 
                {
                    if (dividend == "0") dividend = "";
                    if (remainder == "0") remainder = "";


                    int DivideWithReminder = 0;
                    int.TryParse(dividend, out DivideWithReminder);
                    if(DivideWithReminder < int.Parse(secondNumber) && i > firstNumber.Length - 1)
                    {
                        for (int a = 0; a < dividend.Length; a++)
                        {
                            result += '0';
                        }
                        return result;
                    }
                    dividend += remainder + firstNumber[i]; 
                    if (int.Parse(dividend) > int.Parse(secondNumber) || int.Parse(dividend) == 0) break;
                    i++;
                }

                char resultNumber = ' ';
                for(int k = 0; divider <= int.Parse(dividend); k++)
                {
                    divider += int.Parse(secondNumber);
                    resultNumber = ToChar(k);
                }
                divider -= int.Parse(secondNumber);

                result += resultNumber;

                remainder = Convert.ToString(int.Parse(dividend) - divider);
                divider = 0;
                dividend = "0";
            }

            return result;
        }
    }
}
