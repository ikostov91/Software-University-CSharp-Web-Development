using System;
using System.Collections;
using System.Collections.Generic;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstPlayerCards = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondPlayerCards = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayerDeck = new Queue<string>();
            Queue<string> secondPlayerDeck = new Queue<string>();

            EnqueueCards(firstPlayerDeck, firstPlayerCards);
            EnqueueCards(secondPlayerDeck, secondPlayerCards);

            int numberOfTurns = 0;

            while (numberOfTurns <= 1000000)
            {
                string firstPlayerCurrentCard;
                string secondPlayerCurrentCard;

                try
                {
                    firstPlayerCurrentCard = firstPlayerDeck.Dequeue();
                    secondPlayerCurrentCard = secondPlayerDeck.Dequeue();
                }
                catch (Exception)
                {
                    break;
                }

                numberOfTurns += 1;

                int firstPlayerNumber = int.Parse(firstPlayerCurrentCard.Substring(0, firstPlayerCurrentCard.Length - 1));
                int secondPlayerNumber = int.Parse(secondPlayerCurrentCard.Substring(0, secondPlayerCurrentCard.Length - 1));

                if (firstPlayerNumber == secondPlayerNumber)
                {
                    bool draw = true;

                    Queue<string> firstPlayerTemporaryDeck = new Queue<string>();
                    Queue<string> secondPlayerTemporaryDeck = new Queue<string>();

                    while (draw)
                    {
                        string temporaryCard = string.Empty;

                        if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                        {
                            break;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            try
                            {
                                temporaryCard = firstPlayerDeck.Dequeue();
                                firstPlayerTemporaryDeck.Enqueue(temporaryCard);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Second player wins after {numberOfTurns} turns");
                                return;
                            }

                            try
                            {
                                temporaryCard = secondPlayerDeck.Dequeue();
                                secondPlayerTemporaryDeck.Enqueue(temporaryCard);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"First player wins after {numberOfTurns} turns");
                                return;
                            }
                        }

                        int firstPlayerThreeCardsSum = GetThreeCardsSum(firstPlayerTemporaryDeck);
                        int secondPlayerThreeCardsSum = GetThreeCardsSum(secondPlayerTemporaryDeck);

                        if (firstPlayerThreeCardsSum > secondPlayerThreeCardsSum)
                        {
                            EnqueueCards(firstPlayerDeck, firstPlayerTemporaryDeck.ToArray());
                            EnqueueCards(firstPlayerDeck, secondPlayerTemporaryDeck.ToArray());
                            firstPlayerDeck.Enqueue(firstPlayerCurrentCard);
                            firstPlayerDeck.Enqueue(secondPlayerCurrentCard);
                            draw = false;
                        }
                        else if (secondPlayerThreeCardsSum > firstPlayerThreeCardsSum)
                        {
                            EnqueueCards(secondPlayerDeck, secondPlayerTemporaryDeck.ToArray());
                            EnqueueCards(secondPlayerDeck, firstPlayerTemporaryDeck.ToArray());
                            secondPlayerDeck.Enqueue(secondPlayerCurrentCard);
                            secondPlayerDeck.Enqueue(firstPlayerCurrentCard);
                            draw = false;
                        }
                    }
                }
                else
                {
                    if (firstPlayerNumber > secondPlayerNumber)
                    {
                        firstPlayerDeck.Enqueue(firstPlayerCurrentCard);
                        firstPlayerDeck.Enqueue(secondPlayerCurrentCard);
                    }
                    else
                    {
                        secondPlayerDeck.Enqueue(secondPlayerCurrentCard);
                        secondPlayerDeck.Enqueue(firstPlayerCurrentCard);
                    }
                }
            }

            if (firstPlayerDeck.Count == secondPlayerDeck.Count)
            {
                Console.WriteLine($"Draw after {numberOfTurns} turns");
            }
            else if (firstPlayerDeck.Count > secondPlayerDeck.Count)
            {
                Console.WriteLine($"First player wins after {numberOfTurns} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {numberOfTurns} turns");
            }
        }

        private static int GetThreeCardsSum(Queue<string> firstPlayerDeck)
        {
            int sum = 0;
            char[] alphabet = { '\0', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            for (int i = 0; i < 3; i++)
            {
                string currentCard = firstPlayerDeck.Dequeue();
                char letter = char.Parse(currentCard[currentCard.Length - 1].ToString());

                int index = GetLetterIndex(letter, alphabet);

                sum += index;
            }

            return sum;
        }

        private static int GetLetterIndex(char letter, char[] alphabet)
        {
            int index = 0;

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (letter == alphabet[i])
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private static void EnqueueCards(Queue<string> playerDeck, string[] playerCards, int cards = 0)
        {
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerDeck.Enqueue(playerCards[i]);
            }
        }
    }
}
