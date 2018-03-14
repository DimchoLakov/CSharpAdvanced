using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] secondInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstDeck = new Queue<string>(firstInput);
            Queue<string> secondDeck = new Queue<string>(secondInput);

            int turns = 0;
            bool isVoina = false;

            while (turns < 1000000 && firstDeck.Count > 0 && secondDeck.Count > 0 && !isVoina)
            {
                turns++;

                string firstCard = firstDeck.Dequeue();
                string secondCard = secondDeck.Dequeue();
                int firstCardPower = GetNumberPower(firstCard);
                int secondCardPower = GetNumberPower(secondCard);

                if (firstCardPower > secondCardPower)
                {
                    firstDeck.Enqueue(firstCard);
                    firstDeck.Enqueue(secondCard);
                }
                else if (secondCardPower > firstCardPower)
                {
                    secondDeck.Enqueue(secondCard);
                    secondDeck.Enqueue(firstCard);
                }
                else
                {
                    List<string> cardList = new List<string>() { firstCard, secondCard };
                    while (!isVoina)
                    {
                        if (firstDeck.Count >= 3 && secondDeck.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                string firstPlayerCard = firstDeck.Dequeue();
                                string secondPlayerCard = secondDeck.Dequeue();

                                cardList.Add(firstPlayerCard);
                                cardList.Add(secondPlayerCard);

                                int firstPower = GetCharPower(firstPlayerCard);
                                int secondPower = GetCharPower(secondPlayerCard);

                                firstSum += firstPower;
                                secondSum += secondPower;
                            }


                            if (firstSum > secondSum)
                            {
                                cardList = cardList.OrderByDescending(GetNumberPower).ThenByDescending(GetCharPower).ToList();
                                foreach (string card in cardList)
                                {
                                    firstDeck.Enqueue(card);
                                }
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                cardList = cardList.OrderByDescending(GetNumberPower).ThenByDescending(GetCharPower).ToList();
                                foreach (string card in cardList)
                                {
                                    secondDeck.Enqueue(card);
                                }
                                break;
                            }
                        }
                        else
                        {
                            isVoina = true;
                        }
                    }
                }
            }

            if (firstDeck.Count == secondDeck.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (firstDeck.Count > secondDeck.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (secondDeck.Count > firstDeck.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }

        static int GetCharPower(string card)
        {
            return card[card.Length - 1];
        }

        static int GetNumberPower(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }
    }
}
