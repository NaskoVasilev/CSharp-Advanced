using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();
            List<int> indexes = new List<int>();
            string command = "";

            while ((command = Console.ReadLine()) != "Over!")
            {
                indexes.Clear();
                int length = int.Parse(Console.ReadLine());
                string pattern = @"^\d+([A-Za-z]{" + length + "})[^A-Za-z]*$";

                if (Regex.IsMatch(command, pattern))
                {
                    Match match = Regex.Match(command, pattern);
                    string message = match.Groups[1].Value;

                    for (int i = 0; i < match.Value.Length; i++)
                    {
                        if (char.IsDigit(match.Value[i]))
                        {
                            indexes.Add(int.Parse(match.Value[i].ToString()));
                        }
                    }

                    string verificationCode = "";

                    foreach (var index in indexes)
                    {
                        if (index < message.Length)
                        {
                            verificationCode += message[index];
                        }
                        else
                        {
                            verificationCode += " ";
                        }
                    }

                    messages.Add($"{message} == {verificationCode}");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, messages));
        }
    }
}
