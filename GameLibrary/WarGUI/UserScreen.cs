using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;

namespace WarGUI
{
    public partial class UserScreen : Form
    {
        #region Global Variables
        GameLibrary.War war = null;
        private const int CardsOnTablePerPlayer = 5;
        enum BoardPlayer { WarriorWendy, WhiteWraith }
        #endregion
        #region Events/Screen Initialization
        public UserScreen()
        {
            InitializeComponent();
            MessageBox.Show("Welcome, player!  Please press \"Deal\" to start.  Continue clicking to view each round.  Have fun!", "Welcome!");
        }
        /// <summary>
        /// Set up screen and war object to prepare start of game
        /// </summary>
        private void initGame()
        {
            // set up players and Report delegate fenction
            war = new War((new Player("Warrior Wendy")), (new Player("White Wraith")), War.PlayMode.Graphical, ReportOutcome);
            war.GameOn(); // initialize first round (shuffle/assign cards, etc)

            // should ALWAYS be 26!  Calculate on the fly for debugging purposes
            lblWendyCardCount.Visible = true; lblWendyCardCount.Text = "Cards: " + war.Player1.Hand.Count;
            lblWraithCardCount.Visible = true; lblWraithCardCount.Text = "Cards: " + war.Player2.Hand.Count;

            // first cards are turned over 
            imgPlayer1Card.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            imgPlayer2Card.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;

            // no winner/loser yet, clear textboxes
            lblPlayer1Outcome.Text = "";
            lblPlayer2Outcome.Text = "";
        }
        /// <summary>
        /// Deal each round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeal_Click(object sender, EventArgs e)
        {
            try
            {
                // if this is the first game/round, initialize both screen and war object
                if (war == null) initGame();

                war.Deal(); // deal next round

                // if game is over, declare a winner
                if (war.GameOver) {
                    MessageBox.Show("We have a winner!  " +
                        (war.Winner == war.Player1 ? 
                        "She is the Warrior Wendy!  GIRL POWER!!": 
                        "He is the White Wraith!  Evil has prevailed!")
                        , "WINNER");

                    // offer another game
                    if (MessageBox.Show("Well, wasn't that riveting? How about another round?", "Another Round?", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        initGame(); // re-initialize game
                        initCardImages();
                    }
                    else
                    {
                        MessageBox.Show("Alright, then.  Have a nice day!", "Goodbye!");
                        this.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Fatal exception encountered: " + ex.Message + Environment.NewLine + " at " + ex.StackTrace);
            }

        }
        #endregion
        #region Game Operations
        /// <summary>
        /// Delegate that tells War what to do between each round (i.e. report the outcome of the round)
        /// </summary>
        /// <param name="outcome">Not used, only included to fit delegate in War</param>
        private void ReportOutcome(string outcome = "")
        { 
            // only one card per-person
            if (war != null)
            {
                // hide all card pictures to begin with
                initCardImages();

                // Place cards for each player on the table
                PlaceCards(BoardPlayer.WarriorWendy, war.GameTable.Player1Cards);
                PlaceCards(BoardPlayer.WhiteWraith, war.GameTable.Player2Cards);

                // which of these cards is used to determine winner of round? Should be most recent in list
                Card player1Card = war.GameTable.Player1Cards[war.GameTable.Player1Cards.Count - 1];
                Card player2Card = war.GameTable.Player2Cards[war.GameTable.Player2Cards.Count - 1];     
            
                // rank each card and show winner
                CalculateOutcome(player1Card, player2Card);
            }
        }
        /// <summary>
        /// Decide which of the cards for each player is the winner, or if War must ensue
        /// </summary>
        /// <param name="player1Card">Player 1's card</param>
        /// <param name="player2Card">Player 2's card</param>
        private void CalculateOutcome(Card player1Card, Card player2Card)
        {
            // did player 1 win, or player 2?
            CardRanking rank = war.Rank(player1Card, player2Card);

            // Player 1's card is worth more                              
            if (rank == CardRanking.More)
            {
                // give cards to Wendy, declare her winner.  Update card count for each player
                lblWendyCardCount.Text = "Cards: " + (war.Player1.Hand.Count + war.GameTable.Player1Cards.Count + war.GameTable.Player2Cards.Count);
                lblWraithCardCount.Text = "Cards: " + war.Player2.Hand.Count;
                lblPlayer1Outcome.Visible = true;
                lblPlayer1Outcome.Text = "WINNER!";
                lblPlayer1Outcome.ForeColor = Color.Green;
                lblPlayer2Outcome.Visible = true;
                lblPlayer2Outcome.Text = "LOSER!";
                lblPlayer2Outcome.ForeColor = Color.Red;
            }
            // Player 2's card is worth more
            else if (rank == CardRanking.Less)
            {
                // give cards to wraith, declare him winner.  Update card count for each player
                lblWraithCardCount.Text = "Cards: " + (war.Player2.Hand.Count + war.GameTable.Player1Cards.Count + war.GameTable.Player2Cards.Count);
                lblWendyCardCount.Text = "Cards: " + war.Player1.Hand.Count;
                lblPlayer1Outcome.Visible = true;
                lblPlayer1Outcome.Text = "LOSER!";
                lblPlayer1Outcome.ForeColor = Color.Red;
                lblPlayer2Outcome.Visible = true;
                lblPlayer2Outcome.Text = "WINNER!";
                lblPlayer2Outcome.ForeColor = Color.Green;
            }
            // equal cards
            else
            {
                // no winner, just show what each player has on reserve 
                lblWendyCardCount.Text = "Cards: " + war.Player1.Hand.Count;
                lblWraithCardCount.Text = "Cards: " + war.Player2.Hand.Count;

                lblPlayer1Outcome.Visible = true;
                lblPlayer1Outcome.Text = "WAR!!!";
                lblPlayer1Outcome.ForeColor = Color.Blue;
                lblPlayer2Outcome.Visible = true;
                lblPlayer2Outcome.Text = "WAR!!!";
                lblPlayer2Outcome.ForeColor = Color.Blue;

                // notify player of this stunning development
                MessageBox.Show("Warrior Wendy threw " + war.GameTable.Player1Cards[war.GameTable.Player1Cards.Count - 1].ToString()
                                + ", White Wraith threw " + war.GameTable.Player2Cards[war.GameTable.Player2Cards.Count - 1].ToString()
                                + ". THIS IS WAR!", "AW SNAP, SON!");
            }
        }
        #endregion
        #region Screen Operations
        /// <summary>
        /// Hide all card image placeholders that won't necessarily be used
        /// </summary>
        private void initCardImages()
        {
            // hide all cards, except for front 2 (imgPlayer1Card, imgPlayer2Card), which are always visible/in play
            List<PictureBox> cardImages = new List<PictureBox> ()
                    { imgPlayer1CardB, imgPlayer1CardC, imgPlayer1CardD, imgPlayer1CardE, 
                      imgPlayer2CardB, imgPlayer2CardC, imgPlayer2CardD, imgPlayer2CardE  };
            foreach(PictureBox img in cardImages)
            {
                img.Visible = false;
            }
        }
        /// <summary>
        /// For the given player, decide which cards in the hand should be shown, and where
        /// </summary>
        /// <param name="player"></param>
        /// <param name="hand"></param>
        private void PlaceCards(BoardPlayer player, List<Card> hand)
        {

            int i = war.GameTable.Player1Cards.Count - 1;
            int placedCards = 0;

            // show as many as 5 cards that the user should have on the table
            while (placedCards < CardsOnTablePerPlayer && i >= 0)
            {
                // show most recent in the front
                switch (placedCards)
                {
                    case 0:
                        ShowCard((player == BoardPlayer.WarriorWendy ? imgPlayer1Card : imgPlayer2Card), hand[i]); 
                        break;
                    case 1:
                        ShowCard((player == BoardPlayer.WarriorWendy ? imgPlayer1CardB : imgPlayer2CardB), hand[i]); 
                        break;
                    case 2:
                        ShowCard((player == BoardPlayer.WarriorWendy ? imgPlayer1CardC : imgPlayer2CardC), hand[i]); 
                        break;
                    case 3:
                        ShowCard((player == BoardPlayer.WarriorWendy ? imgPlayer1CardD : imgPlayer2CardD), hand[i]); 
                        break;
                    case 4:
                        ShowCard((player == BoardPlayer.WarriorWendy ? imgPlayer1CardE : imgPlayer2CardE), hand[i]); 
                        break;
                }
                placedCards++;
                i--;
            }
        }
        /// <summary>
        /// Handles showing the appropriate card image for a given card
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="card"></param>
        private void ShowCard(PictureBox pic, Card card)
        {
            pic.Visible = true;
            if (!card.Visible) // if card is flipped over, show as such
            {
                pic.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            }
            else
            {
                if (card.Suit == CardSuit.Clubs)
                {
                    switch (card.Name)
                    {
                        case CardName.Two:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._2Clubs;
                            break;
                        case CardName.Three:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._3Clubs;
                            break;
                        case CardName.Four:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._4Clubs;
                            break;
                        case CardName.Five:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._5Clubs;
                            break;
                        case CardName.Six:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._6Clubs;
                            break;
                        case CardName.Seven:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._7Clubs;
                            break;
                        case CardName.Eight:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._8Clubs;
                            break;
                        case CardName.Nine:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._9Clubs;
                            break;
                        case CardName.Ten:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._10Clubs;
                            break;
                        case CardName.Jack:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.JackClubs;
                            break;
                        case CardName.Queen:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.QueenClubs;
                            break;
                        case CardName.King:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.KingClubs;
                            break;
                        case CardName.Ace:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.AceClubs;
                            break;
                    }
                }
                else if (card.Suit == CardSuit.Diamonds)
                {
                    switch (card.Name)
                    {
                        case CardName.Two:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.TwoDiamonds;
                            break;
                        case CardName.Three:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._3Diamonds;
                            break;
                        case CardName.Four:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._4Diamonds;
                            break;
                        case CardName.Five:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._5Diamonds;
                            break;
                        case CardName.Six:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._6Diamonds;
                            break;
                        case CardName.Seven:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._7Diamonds;
                            break;
                        case CardName.Eight:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._8Diamonds;
                            break;
                        case CardName.Nine:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._9Diamonds;
                            break;
                        case CardName.Ten:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._10Diamonds;
                            break;
                        case CardName.Jack:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.JackDiamonds;
                            break;
                        case CardName.Queen:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.QueenDiamonds;
                            break;
                        case CardName.King:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.KingDiamonds;
                            break;
                        case CardName.Ace:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.AceDiamonds;
                            break;
                    }
                }
                else if (card.Suit == CardSuit.Hearts)
                {
                    switch (card.Name)
                    {
                        case CardName.Two:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._2Hearts;
                            break;
                        case CardName.Three:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._3Hearts;
                            break;
                        case CardName.Four:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._4Hearts;
                            break;
                        case CardName.Five:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._5Hearts;
                            break;
                        case CardName.Six:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._6Hearts;
                            break;
                        case CardName.Seven:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._7Hearts;
                            break;
                        case CardName.Eight:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._8Hearts;
                            break;
                        case CardName.Nine:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._9Hearts;
                            break;
                        case CardName.Ten:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._10Hearts;
                            break;
                        case CardName.Jack:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.JackHearts;
                            break;
                        case CardName.Queen:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.QueenHearts;
                            break;
                        case CardName.King:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.KingHearts;
                            break;
                        case CardName.Ace:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.AceHearts;
                            break;
                    }
                }
                else
                {
                    // call a spade a spade
                    switch (card.Name)
                    {
                        case CardName.Two:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._2Spades;
                            break;
                        case CardName.Three:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._3Spades;
                            break;
                        case CardName.Four:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._4Spades;
                            break;
                        case CardName.Five:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._5Spades;
                            break;
                        case CardName.Six:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._6Spades;
                            break;
                        case CardName.Seven:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._7Spades;
                            break;
                        case CardName.Eight:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._8Spades;
                            break;
                        case CardName.Nine:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._9Spades;
                            break;
                        case CardName.Ten:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources._10Spades;
                            break;
                        case CardName.Jack:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.JackSpades;
                            break;
                        case CardName.Queen:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.QueenSpades;
                            break;
                        case CardName.King:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.KingSpades;
                            break;
                        case CardName.Ace:
                            pic.BackgroundImage = global::WarGUI.Properties.Resources.AceSpades;
                            break;
                    }
                }
            }
           
            pic.Invalidate(); // make sure screen refreshes
        }
        #endregion

    }
}
