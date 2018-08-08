using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    #region War Class
    public class War : IGame
    {
        #region Private Members, Properties

        public enum PlayMode { Continuous = 0, PlayByPlay = 1, Graphical = 2 }

        public bool GameOver { get; private set; } // did anyone win yet?
        public Player Winner { get; private set; } // winner of the game, set to Player1 or Player2

        public Table GameTable { get; set; } // represents which cards are on the table, and which player they belong to
        private CardDeck _deck = null;       // deck of cards in play
        public PlayMode GameMode { get; private set; } // if set in "PlayByPlay", pause in console between each round

        public Player Player1 { get; private set; } // list of players
        public Player Player2 { get; private set; }

        public int TotalRounds { get; private set; } // cool and interesting stats for user
        public int TotalWars { get; private set; }

        private int _reshuffleCounter = 0;
        private const int ReShuffleLimit = 10; // re-shuffle cards after so-many rounds

        // invoking code must set a procedure to handle reporting results to user. Different for Console vs. GUI
        public delegate void ReportFunc(string info);
        private ReportFunc _Report = null;

        #endregion  

        #region Initializers
        // set up rudimentary game properties
        public War(Player player1, Player player2, PlayMode mode, ReportFunc reportFunc) 
        { 
            GameOver = false; 
            Player1 = player1; 
            Player2 = player2;
            Winner = null;
            GameTable = new Table();
            this.GameMode = mode;
            this._Report = reportFunc;
        }
        /// <summary>
        /// Ready to start a new game.  Shuffle/assign cards, initialize properties for one game
        /// </summary>
        public void GameOn() 
        {
            // if no players are set, set up de-facto players
            if (Player1 == null) Player1 = new Player("User Player");
            if (Player2 == null) Player2 = new Player("Adversary");
            _deck = new CardDeck();
            // distribute shuffled cards to players, 26 each
            List<List<Card>> subDecks = _deck.Cards.Select((x, i) => new { Index = i, Value = x })
                                            .GroupBy(x => x.Index < 26)
                                            .Select(x => x.Select(v => v.Value).ToList())
                                            .ToList();
            Player1.AddCards(subDecks[0]);
            Player2.AddCards(subDecks[1]);

            _reshuffleCounter = 0;
            TotalRounds = 0;
            TotalWars = 0;

        }
        #endregion

        #region Game Operations
        /// <summary>
        /// Draw a card from each player's pile, determine who wins the round
        /// </summary>
        public void Deal()
        {

            TotalRounds++;

            // each player puts a card onto the table, face up
            Card player1Card = Player1.Deal(true);
            if(player1Card != null) // should only happen when user is out of cards
                GameTable.AddCard(1, player1Card);
            Card player2Card = Player2.Deal(true);
            if(player2Card != null)
                GameTable.AddCard(2, player2Card);

            // which player's card wins?
            switch(Rank(player1Card, player2Card))
            {
                case CardRanking.Equal:

                    // if one player has won (i.e. out of cards), end game now, otherwise go to war
                    if (!CheckWinner())
                    {
                        this._Report(player1Card.ToString() + " and " + player2Card.ToString() + ". THIS MEANS WAR!");
                        TotalWars++;

                        //  If one player only has one card left, don't draw it, save until next round
                        if (Player1.Hand.Count > 1)
                        {
                            player1Card = Player1.Deal(false); // draw face-down card
                            GameTable.AddCard(1, player1Card);
                        }
                        if (Player2.Hand.Count > 1)
                        {
                            player2Card = Player2.Deal(false);
                            GameTable.AddCard(2, player2Card);
                        }

                        Deal();
                    }
                    break;

                case CardRanking.More:
                    this._Report(player1Card.ToString() + " beats " + player2Card.ToString() + "." + Environment.NewLine + Player1.Name + " wins this round.");
                    GameTable.Award(Player1);
                    CheckWinner();
                    break;

                case CardRanking.Less:
                    this._Report(player2Card.ToString() + " beats " + player1Card.ToString() + "." + Environment.NewLine + Player2.Name + " wins this round.");
                    GameTable.Award(Player2);
                    CheckWinner();
                    break;
            }

            // periodically re-shuffle each players' hands so we don't get caught in infinite loops
            _reshuffleCounter++;
            if (_reshuffleCounter >= ReShuffleLimit)
            { 
                Player1.Hand = CardDeck.Shuffle(Player1.Hand);
                Player2.Hand = CardDeck.Shuffle(Player2.Hand);
                _reshuffleCounter = 0;
            }
        }
        /// <summary>
        /// Determine which of these cards is greater
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns>Equal if cards are the same, More if card1 wins, Less if card2 wins</returns>
        public CardRanking Rank(Card card1, Card card2) 
        {
            if (card1.Name == card2.Name)
                return CardRanking.Equal;
            // Ace has enum 0, but it beats out any other card.  Whoever has Ace wins
            else if (card1.Name == CardName.Ace || card2.Name == CardName.Ace)
                return (card1.Name == CardName.Ace ? CardRanking.More : CardRanking.Less);
            else
                // can fall back on enum values to compare which is greater
                return ((int)card1.Name > (int)card2.Name ? CardRanking.More : CardRanking.Less);
        }
        /// <summary>
        /// Output a string to display information on the current round.  Good for Console or File outputs
        /// </summary>
        /// <param name="state"></param>
        /// <returns>String with round information</returns>
        public string GameState(string state)
        {
            StringBuilder output = new StringBuilder();

            // will show each player in 2 columns.  Decide how wide each column should be, and width of border between them
            const int colWidth = 20;
            const int borderWidth = 5;

            // output players' names
            string tempName = Player1.Name;
            if (tempName.Length > colWidth) tempName = tempName.Substring(0, colWidth);
            output.Append(tempName.PadRight(colWidth));
            output.Append("".PadRight(borderWidth));
            tempName = Player2.Name;
            if (tempName.Length > colWidth) tempName = tempName.Substring(0, colWidth);
            output.AppendLine(tempName.PadRight(colWidth));

            // underline players' names
            output.AppendLine("".PadRight(colWidth, '-') + "".PadRight(borderWidth) + "".PadRight(colWidth, '-'));

            // show cards that each player has on the table.  Go by maximum between the two so we have enough lines
            int allCards = GameTable.Player1Cards.Count;
            if (GameTable.Player2Cards.Count > allCards) allCards = GameTable.Player2Cards.Count;

            for (int i = 0; i < allCards; i++)
            {
                // does this player have a card for this slot? (in case it's near the end of the game, and one player has placed more cards than the other player on the table)
                if (GameTable.Player1Cards.Count > i)
                    output.Append(GameTable.Player1Cards[i].ToString().PadRight(colWidth));
                else
                    output.Append("".PadRight(colWidth)); // otherwise pad with spaces to offset column for player 2's card (if there)

                // separate by border
                output.Append("".PadRight(borderWidth));

                // same logic as player 1
                if (GameTable.Player2Cards.Count > i)
                    output.AppendLine(GameTable.Player2Cards[i].ToString().PadRight(colWidth));
            }
            // show remark that called this function
            output.AppendLine(Environment.NewLine + state + Environment.NewLine);

            // divider to separate this from the next entry
            output.AppendLine("".PadRight((colWidth * 2) + borderWidth, '-') + Environment.NewLine + Environment.NewLine);
            return output.ToString();
        }
        /// <summary>
        /// Check both players' hands to see if we can declare a winner. Whoever is out of cards, loses
        /// </summary>
        /// <returns></returns>
        public bool CheckWinner()
        {
            if (Player1.Hand.Count <= 0)
            {
                Winner = Player2;
                this.GameOver = true;
            }
            else if (Player2.Hand.Count <= 0)
            {
                Winner = Player1;
                this.GameOver = true;
            }
            return this.GameOver;
        }
        #endregion
    }
    #endregion
    #region Player Class
    /// <summary>
    /// Object to represent a player on the table, their name, the cards they hold.  Use Deal() function
    /// to simulate placing a card from their hand onto the table
    /// </summary>
    public class Player : IPlayer
    {
        public List<Card> Hand = null; // total cards that belong to this player
        public string Name { get; private set; } 
        // initialize player
        public Player(string name) {
            this.Name = name;
            Hand = new List<Card>();
        }
        // take one card from the deal's hand (or pile, in the case of war)
        public Card Deal(bool faceUp) {
            if (Hand.Count <= 0) return null;
            else
            {
                // draw from top of their pile
                Card drawn = Hand.Last();
                if(faceUp) drawn.Flip();
                Hand.RemoveAt(Hand.Count - 1);
                return drawn;
            }
        }
        // give user cards; they go to the bottom of the deck, so use Insert()
        public void AddCards(List<Card> toAdd)
        {
            // all cards in deck must be face down
            toAdd.Where(c => c.Visible).ForEach(c => c.Flip());
            Hand.InsertRange(0, toAdd);
        }
    }
    #endregion
    #region Table Class
    // simulate cards on the game's table
    public class Table
    {
        // cards that each player has placed on the table
        public List<Card> Player1Cards { get; private set; } 
        public List<Card> Player2Cards { get; private set; }

        public Table()
        {
            Player1Cards = new List<Card>();
            Player2Cards = new List<Card>();
        }

        /// <summary>
        /// place card on the table from the specified player 
        /// </summary>
        /// <param name="playerNum"></param>
        /// <param name="card"></param>
        public void AddCard(int playerNum, Card card) 
        {
            if (playerNum == 1) Player1Cards.Add(card); 
            else Player2Cards.Add(card); 
        }

        /// <summary>
        /// give all cards on the table to this player
        /// </summary>
        /// <param name="winner"></param>
        public void Award(Player winner)
        {
            winner.AddCards(Player1Cards); Player1Cards.Clear();
            winner.AddCards(Player2Cards); Player2Cards.Clear();
        }
    }
    #endregion
}
