using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxText.Helper_Methods
{
    public static class DelimitedStringHelperClass
    {

        public static string RetureItemAtPosition(string InputString, char Delimiter, int Position)
        {
            if (InputString.IndexOf(Delimiter) == -1) return InputString;
            string[] items = InputString.Split(Delimiter);
            string outputString = items[Position];
            return outputString;
        }

        public static string replaceNthItemInDelimitedString(string inputString, char del, int itemNumber, string replacementString)
        {
            string[] items = inputString.Split(del);
            items[itemNumber] = replacementString;
            string outputString = "";
            for (int i = 0; i < items.Length; i++)
            {
                outputString = outputString + items[i] + del;
            }
            outputString = outputString.Substring(0, outputString.Length - 1);
            return outputString;
        }

        public static string RetrunAlphaNumberString(int number, int AlphaBase)
        {
            string alphaNumber = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            switch (AlphaBase)
            {
                //a single letter ie AlphaNumber = 1
                case 1:
                    alphaNumber = alphabet[number].ToString();
                    break;
                // two letters ie AlphaNumber = 2
                case 2:
                    int firstLetterInt = number / 26;
                    int secondLetterInt = number % 26;

                    alphaNumber = alphabet[firstLetterInt].ToString() + alphabet[secondLetterInt].ToString();
                    break;
            }
            return alphaNumber;
        }
    }
}
