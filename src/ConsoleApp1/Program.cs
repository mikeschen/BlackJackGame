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
                    if (j <= 8)
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
                Console.WriteLine("card" + card);
                Console.WriteLine("cardsorigin" + cards[originalCards]);
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                int total = Deal();
                Hit(total);
                Console.ReadLine();
            }
            public static int Deal()
            {
                int total = 0;
                Deck myDeck = new Deck();
                Card firstPlayerCard = myDeck.cards[0];
                Card secondPlayerCard = myDeck.cards[1];
                Console.WriteLine(firstPlayerCard.Face + " of " + firstPlayerCard.Suit);
                total = firstPlayerCard.Value;
                total += secondPlayerCard.Value;
                Console.WriteLine(secondPlayerCard.Face + " of " + secondPlayerCard.Suit);
                Console.WriteLine("Total: " + total);
                return total;
            }

            public static void Hit(int total)
            {
                Console.WriteLine("hit or stand?");
                var response = Console.ReadLine();
                if (response == "hit") { 
                    var rnd = new Random();
                    var result = rnd.Next(52);
                    Deck myDeck = new Deck();
                    total += myDeck.cards[result].Value;
                    Console.WriteLine(myDeck.cards[result].Face + " of " + myDeck.cards[result].Suit);
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
            }
        }
    }
}
