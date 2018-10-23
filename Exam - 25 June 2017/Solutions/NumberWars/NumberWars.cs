using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberWars
{
    class NumberWars
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            int counter = 1;
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet.Add(i, counter++);
            }

            string[] firstPlayer = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<KeyValuePair<char, int>> firstPlayerCards = new Queue<KeyValuePair<char, int>>();
            FillQueue(firstPlayerCards, firstPlayer);

            string[] secondPlayer = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<KeyValuePair<char, int>> secondPlayerCards = new Queue<KeyValuePair<char, int>>();
            FillQueue(secondPlayerCards, secondPlayer);

            List<KeyValuePair<char, int>> cardsToAdd = new List<KeyValuePair<char, int>>();
            int turns = 0;
            bool gameOver = false;

            while (!gameOver && turns < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                turns++;
                int firstPlayerNumber = firstPlayerCards.Peek().Value;
                int secondPlayerNumber = secondPlayerCards.Peek().Value;

                cardsToAdd.Add(firstPlayerCards.Dequeue());
                cardsToAdd.Add(secondPlayerCards.Dequeue());

                if (firstPlayerNumber > secondPlayerNumber)
                {
                    AddCards(firstPlayerCards, cardsToAdd);
                }
                else if (secondPlayerNumber > firstPlayerNumber)
                {
                    AddCards(secondPlayerCards, cardsToAdd);
                }
                else
                {
                    while (!gameOver)
                    {
                        if (secondPlayerCards.Count >= 3 && firstPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                char letter = firstPlayerCards.Peek().Key;
                                firstSum += alphabet[letter];
                                cardsToAdd.Add(firstPlayerCards.Dequeue());

                                letter = secondPlayerCards.Peek().Key;
                                secondSum += alphabet[letter];
                                cardsToAdd.Add(secondPlayerCards.Dequeue());
                            }

                            if (firstSum > secondSum)
                            {
                                AddCards(firstPlayerCards, cardsToAdd);
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                AddCards(secondPlayerCards, cardsToAdd);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                            break;
                        }
                    }
                }
            }

            if (secondPlayerCards.Count == firstPlayerCards.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (secondPlayerCards.Count > firstPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
        }

        private static void FillQueue(Queue<KeyValuePair<char, int>> playerCards, string[] inputCards)
        {
            foreach (var card in inputCards)
            {
                playerCards.Enqueue(new KeyValuePair<char, int>(GetCardLetter(card), GetCardNumber(card)));
            }
        }

        private static void AddCards(Queue<KeyValuePair<char, int>> cards, List<KeyValuePair<char, int>> cardsToAdd)
        {
            foreach (var card in cardsToAdd.OrderByDescending(x => x.Value).ThenByDescending(x=>(int)x.Key))
            {
                cards.Enqueue(card);
            }

            cardsToAdd.Clear();
        }

        private static int GetCardNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static char GetCardLetter(string card)
        {
            return card[card.Length - 1];
        }
    }
}
