using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int countOFUsernames = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < countOFUsernames; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
