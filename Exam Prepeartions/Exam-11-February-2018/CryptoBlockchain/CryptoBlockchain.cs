using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            string pattern = @"{[^{\[\]]+}|\[[^\[{}]+\]";
            int n = int.Parse(Console.ReadLine());
            string input = "";
            for (int i = 0; i < n; i++)
            {
                input += Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(input, pattern);
            string numberPattern = @"\d{3}";
            string output = "";

            foreach (var match in matches)
            {
                string digits = new string(match.ToString().Where(x => char.IsDigit(x)).ToArray());
                if (digits.Length > 0 && digits.Length % 3 == 0)
                {
                    MatchCollection numbers = Regex.Matches(digits, numberPattern);
                    foreach (var num in numbers)
                    {
                        int code = int.Parse(num.ToString()) - match.ToString().Length;
                        output += (char)code;
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
