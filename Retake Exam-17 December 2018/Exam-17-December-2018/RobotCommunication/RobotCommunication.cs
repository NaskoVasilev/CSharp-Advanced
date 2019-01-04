using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RobotCommunication
{
    class RobotCommunication
    {
        static void Main(string[] args)
        {
            string pattern = @"(,|_)([A-Za-z]+)[0-9]{1}";
            Regex regex = new Regex(pattern);
            string command = "";

            while ((command = Console.ReadLine()) != "Report")
            {
                string output = "";

                MatchCollection matches = regex.Matches(command);

                foreach (Match match in matches)
                {
                    string letters = match.Groups[2].Value;
                    int value = int.Parse(match.Value[match.Value.Length - 1].ToString());
                    char begining = match.Value[0];

                    output += DecodeMessage(letters, value, begining) + " ";
                }

                Console.WriteLine(output.Substring(0, output.Length - 1));
            }
        }

        private static string DecodeMessage(string letters, int value, char begining)
        {
            StringBuilder sb = new StringBuilder();

            if (begining == '_')
            {
                foreach (char letter in letters)
                {
                    sb.Append((char)((int)letter - value));
                }
            }
            else if (begining == ',')
            {
                foreach (char letter in letters)
                {
                    sb.Append((char)((int)letter + value));
                }
            }

            return sb.ToString();
        }
    }
}
