using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    interface IGame
    {
        /// <summary>
        /// How should two cards be ranked?  Which one is the winner?
        /// </summary>
        /// <param name="card1">First card to compare</param>
        /// <param name="card2">Second card to compare to the first</param>
        /// <returns></returns>
        CardRanking Rank(Card card1, Card card2);
        /// <summary>
        /// Program how each round needs to work
        /// </summary>
        void Deal();
        /// <summary>
        /// Handle initalization of the game, such as shuffling cards and assigning them
        /// </summary>
        void GameOn();
    }
    public enum CardRanking { Less = -1, Equal = 0, More = 1 }
    /// <summary>
    /// How should Player's cards operate in a given round?  When cards are added to the player's hand, what should they do?
    /// e.g. sort themselves, get put face down, go to bottom of the deck, etc.
    /// </summary>
    interface IPlayer
    {
        Card Deal(bool faceUp);
        void AddCards(List<Card> toAdd);
    }
}
