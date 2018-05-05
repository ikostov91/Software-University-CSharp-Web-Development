using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NumberWarsTrainerSolution
{
    class Program
    {
        public const int maxCounter = 1_000_000;

        static void Main(string[] args)
        {
            Queue<string> firstAllCards = new Queue<string>(Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None));
            Queue<string> secondAllCards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None));

            int turnCounter = 0;
            bool gameOver = false;

            while (turnCounter < maxCounter && firstAllCards.Count > 0 && secondAllCards.Count > 0 && !gameOver)
            {
                turnCounter++;

                string firstCard = firstAllCards.Dequeue();
                string secondCard = secondAllCards.Dequeue();

                // var compareResult = GetNumber(firstCard).CompareTo(GetNumber(secondCard));
                // 1 - firstCard is larger, 0 if equal, -1 if secondCard is larger

                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> cardsHand = new List<string> { firstCard, secondCard };

                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int counter = 0; counter < 3; counter++)
                            {
                                string firstHandCard = firstAllCards.Dequeue();
                                string secondHandCard = secondAllCards.Dequeue();

                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);

                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsHand, firstAllCards);
                                break;
                            }

                            if (firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsHand, secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = "";

            if (firstAllCards.Count == secondAllCards.Count)
            {
                result = "Draw";
            }
            else if (firstAllCards.Count > secondAllCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnCounter} turns");
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        private static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
