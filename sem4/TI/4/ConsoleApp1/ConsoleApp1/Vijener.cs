using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4
{
    internal class Vijener
    {
        public static string VijenerEncrypt(string inputString, string keyWord)
        {
            inputString = inputString.ToLower();
            keyWord = keyWord.ToLower();

            string encryptedString = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == ' ')
                {
                    encryptedString += ' ';
                    continue;
                }
                int encryptingChar = (char)(inputString[i] + (keyWord[i % keyWord.Length] - 'a'));
                if (encryptingChar > 122) encryptingChar = (encryptingChar % 122) + 96;
                encryptedString += (char)encryptingChar;
            }

            return encryptedString;
        }

        public static string VijenarDecrypt(string inputString, string keyWord)
        {
            inputString = inputString.ToLower();
            keyWord = keyWord.ToLower();

            string decryptedString = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == ' ')
                {
                    decryptedString += ' ';
                    continue;
                }
                int decryptingChar = (char)(inputString[i] - (keyWord[i % keyWord.Length] - 'a'));
                if (decryptingChar < 97) decryptingChar = decryptingChar + 26;
                decryptedString += (char)decryptingChar;
            }

            return decryptedString;
        }
    }
}

