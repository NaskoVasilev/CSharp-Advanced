using System;
using System.Collections.Generic;
using System.Linq;

namespace TagRam
{
    class TagRam
    {
        static void Main(string[] args)
        {

            var users = new Dictionary<string, Dictionary<string, int>>();
            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length < 2)
                {
                    string username = data[0].Substring(4);
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
                else
                {
                    string username = data[0];
                    string tagName = data[1];
                    int likes = int.Parse(data[2]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(tagName))
                    {
                        users[username].Add(tagName, 0);
                    }
                    users[username][tagName] += likes;
                }
            }

            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
