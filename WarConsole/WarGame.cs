using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace WarConsole
{
    class WarGame
    {
        private static War game = null;

        static void Main(string[] args)
        {
            try
            {
                // start-up, let user input name and decide game option
                Console.WriteLine("Greetings, Player!  Please start by entering your name and hitting ENTER.");
                string playerName = Console.ReadLine();
                Console.WriteLine("Very good, " + playerName + ".  Would you like to view this game play-by-play? (y/n)");
                string answer = Console.ReadLine();
                while(!(new List<String>() { "YES", "NO", "Y", "N" }).Contains(answer.ToUpper()))
                {
                    Console.WriteLine("Let's try that again. Please press Y or N and hit ENTER to answer.\nWould you like to view this game hand-by-hand? (y/n)");
                    answer = Console.ReadLine();
                }

                // ask the user if they want to either view each play, or let program run continuously until winner is found
                War.PlayMode gameMode = (answer.ToUpper() == "Y" || answer.ToUpper() == "YES" ? War.PlayMode.PlayByPlay : War.PlayMode.Continuous);

                if (gameMode == War.PlayMode.PlayByPlay) Console.WriteLine("You got it, " + playerName + "!  Please press ENTER between each play." + Environment.NewLine);

                // initialize War game engine
                game = new War(new Player(playerName), new Player("Opponent"), gameMode, ConsoleOutput);
                game.GameOn();

                // loop rounds until it's over.
                while (!game.GameOver)
                    game.Deal();
                    
                // show results
                Console.WriteLine(game.Winner.Name + " has won the game!  Good job " + game.Winner.Name + "!  Better luck next time, " +
                    (game.Winner == game.Player1 ? game.Player2.Name : game.Player1.Name) + "!" + Environment.NewLine + Environment.NewLine + 
                    "STATS: " + game.TotalRounds + " total rounds played.  " + 
                    (game.TotalWars == 0 ? "War was never declared.  Three cheers for pacifists!" :
                                            "War was declared " + (game.TotalWars == 1 ? "once." :
                                                                   game.TotalWars == 2 ? "twice." : 
                                                                   game.TotalWars.ToString() + " times.")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encountered! " + e.ToString());
            }

            // let user view results before closing
            Console.WriteLine(Environment.NewLine + "Press ENTER to close.");
            Console.ReadLine();
        }

        /// <summary>
        /// Delegate used in War class.  Determines how results are shown to the user.
        /// </summary>
        /// <param name="roundInfo"></param>
        public static void ConsoleOutput(string roundInfo)
        {
            if (!game.GameOver)
            {
                Console.WriteLine(game.GameState(roundInfo));
                if (game.GameMode == War.PlayMode.PlayByPlay)
                    Console.ReadLine();
            }
            else
            {
                // game is over, just output whatever final message was passed in.
                Console.WriteLine(roundInfo);
                Console.ReadLine();
            }
        }
    }
}
