using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum Suit
    {
        Heart, Diamond, Spade, Club
    }
    public enum Face
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    class Card
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }
        public int Value { get; set; }
    }

    class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    cards.Add(new Card() { Suit = (Suit)i, Face = (Face)j });
                    if(j == 0)
                    {
                        cards[cards.Count - 1].Value = 11;
                    } else if (j <= 8)
                    {
                        cards[cards.Count - 1].Value = j + 1;
                    } else
                    {
                        cards[cards.Count - 1].Value = 10;
                    }
                }
            }
            Random rnd = new Random();
            int originalCards = cards.Count;
            while (originalCards > 1)
            {
                originalCards--;
                int nextCard = rnd.Next(originalCards + 1);
                Card card = cards[nextCard];
                cards[nextCard] = cards[originalCards];
                cards[originalCards] = card;
            }
        }

        public class Program
        {
            public static void Main()
            {
                int playerTotal = Deal();
                playerTotal = Hit(playerTotal);
                if (playerTotal > 21)
                {
                    Console.WriteLine("Player Loses!");
                    Console.ReadLine();
                }
                else
                {
                    int compTotal = Dealer();
                    if (compTotal > 21) {
                        Console.WriteLine("Computer Loses!");
                    } else if (playerTotal == compTotal)
                    {
                        Console.WriteLine("Push");
                    } else if (playerTotal > compTotal)
                    {
                        Console.WriteLine("Player Wins!!!");
                    } else
                    {
                        Console.WriteLine("Computer Wins!!!");
                    }
                    Console.ReadLine();
                }
            }
            public static int Deal()
            {
                int total = 0;
                Deck myDeck = new Deck();
                Card firstPlayerCard = myDeck.cards[0];
                myDeck.cards.RemoveAt(0);
                Card secondPlayerCard = myDeck.cards[0];
                myDeck.cards.RemoveAt(0);
                Console.WriteLine(firstPlayerCard.Face + " of " + firstPlayerCard.Suit);
                total = firstPlayerCard.Value;
                total += secondPlayerCard.Value;
                Console.WriteLine(secondPlayerCard.Face + " of " + secondPlayerCard.Suit);
                Console.WriteLine("Total: " + total);
                return total;
            }

            public static int Hit(int total)
            {
                Console.WriteLine("hit or stand?");
                var response = Console.ReadLine();
                if (response == "hit") { 
                    Deck myDeck = new Deck();
                    total += myDeck.cards[0].Value;
                    Console.WriteLine("Total: " + total);
                    Console.WriteLine(myDeck.cards[0].Face + " of " + myDeck.cards[0].Suit);
                    if (total > 21)
                    {
                        Console.WriteLine(total + " Bust!!!!");
                    } else
                    {
                        Hit(total);
                    }
                } else if (response == "stand")
                {
                Console.WriteLine(total + " Stand");
                }
                return total;
            }

            public static int Dealer()
            {
                int computerTotal = 0;
                Deck myDeck = new Deck();
                Card firstComputerCard = myDeck.cards[0];
                myDeck.cards.RemoveAt(0);
                Card secondComputerCard = myDeck.cards[0];
                myDeck.cards.RemoveAt(0);
                Console.WriteLine("Computer: " + firstComputerCard.Face + " of " + firstComputerCard.Suit);
                computerTotal = firstComputerCard.Value;
                computerTotal += secondComputerCard.Value;
                Console.WriteLine("Computer: " + secondComputerCard.Face + " of " + secondComputerCard.Suit);
                Console.WriteLine("Computer Total: " + computerTotal);
                while(computerTotal < 17)
                {
                    computerTotal += myDeck.cards[0].Value;
                    Console.WriteLine(myDeck.cards[0].Face + " of " + myDeck.cards[0].Suit);
                    Console.WriteLine("Computer Total: " + computerTotal);
                    myDeck.cards.RemoveAt(0);
                }
                return computerTotal;
            }
        }
    }
}
