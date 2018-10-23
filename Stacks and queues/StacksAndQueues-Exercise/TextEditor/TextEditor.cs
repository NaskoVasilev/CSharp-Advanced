using System;
using System.Collections.Generic;

namespace TextEditor
{
    class TextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> storage = new Stack<string>();
            storage.Push("");

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string command = tokens[0];

                switch (command)
                {
                    case "1":
                        string text = storage.Peek() + tokens[1];
                        storage.Push(text);
                        break;
                    case "2":
                        text = storage.Peek();
                        int count = int.Parse(tokens[1]);
                        int length = text.Length - count;
                        if (length < 0)
                        {
                            length = 0;
                        }
                        text = text.Substring(0, length);
                        storage.Push(text);
                        break;
                    case "3":
                        int index = int.Parse(tokens[1]);
                        text = storage.Peek();
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        storage.Pop();
                        break;
                }
            }
        }
    }
}
