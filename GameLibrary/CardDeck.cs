using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    #region CardDeck class
    public class CardDeck
    {
        // all cards in our deck
        public List<Card> Cards { get; private set; }

        /// <summary>
        /// initialize standard card deck with all 52 standard cards, and shuffle them
        /// </summary>
        public CardDeck()
        {
            generate();
            Cards = CardDeck.Shuffle(Cards);
        }

        /// <summary>
        /// Populate our internal deck with all standard 52 cards
        /// </summary>
        private void generate()  
        { 
            Cards = new List<Card>();

            // iterate through all permutations of known card names/suits/colros
            var names = Enum.GetValues(typeof(CardName)).Cast<CardName>();
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var colors = Enum.GetValues(typeof(CardColor)).Cast<CardColor>();

            foreach (CardName name in names)
                foreach (CardSuit suit in suits)
                    Cards.Add(new Card(name, suit, (suit == CardSuit.Diamonds || suit == CardSuit.Hearts ? CardColor.Red : CardColor.Black)));
        }

        /// <summary>
        /// Shuffle a list of cards (can be used externally, too, with a variable list of cards)
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static List<Card> Shuffle(List<Card> cards)
        {
            if (cards == null || cards.Count <= 0) return cards;

            List<Card> shuffled = new List<Card>();
            Random randomizer = new Random();
            // shuffle every card, insert into new list
            while (cards.Count > 0)
            {
                if (cards.Count == 1) {
                    shuffled.Add(cards[0]); break;
                } else {
                    int cardIdx = randomizer.Next(cards.Count);
                    shuffled.Add(cards[cardIdx]);
                    cards.RemoveAt(cardIdx);
                }
            }
            return shuffled;
        }

        #region Debugging
        /// <summary>
        /// Output a line for each card
        /// </summary>
        /// <param name="cards"></param>
        public static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
                System.Diagnostics.Debug.Print(card.ToString());
        }
        /// <summary>
        /// Get a list of cards and throw them all into one string
        /// </summary>
        /// <param name="cards"></param>
        public static string CardsToString(List<Card> cards)
        {
            StringBuilder output = new StringBuilder();
            foreach (Card card in cards)
                output.AppendLine(card.ToString());
            return output.ToString();
        }
        #endregion
    }
    #endregion
    #region Card Class
    public class Card
    {
        public CardName Name { get; private set; }
        public CardSuit Suit { get; private set; }      // NOTE: not used yet, but can be handy in the future
        public CardColor Color { get; private set; }    
        public bool Visible { get; set; }

        public Card(CardName name, CardSuit suit, CardColor color) {
            Name = name; Suit = suit; Color = color; Visible = true;
        }
        public void Flip() { Visible = !Visible; }
        public override string ToString()
        {
            return Enum.GetName(typeof(CardName), Name) + " of " + Enum.GetName(typeof(CardSuit), Suit);
        }
    }
    public enum CardName
    {  Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13 }
    public enum CardSuit { Hearts = 0, Diamonds = 1, Spades = 2, Clubs = 3 }
    public enum CardColor { Black = 0, Red = 1 }
    #endregion
}
