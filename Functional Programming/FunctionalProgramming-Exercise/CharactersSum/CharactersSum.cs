using System;

namespace CharactersSum
{
    class CharactersSum
    {
        static string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        static void Main(string[] args)
        {
            int maxCharacterSum = int.Parse(Console.ReadLine());

            Func<string, bool> isMagicWord = (word) =>
            {
                int sum = 0;

                foreach (char letter in word)
                {
                    sum += (int)letter;
                }
                if (maxCharacterSum <= sum)
                {
                    return true;
                }
                return false;
            };

            FindMagicWord(words, isMagicWord);
        }

        private static void FindMagicWord(string[] words, Func<string, bool> isMagicWord)
        {
            foreach (var word in words)
            {
                if (isMagicWord(word))
                {
                    Console.WriteLine(word);
                    break;
                }
            }
        }
    }
}
