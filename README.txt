NOTES:

This program is written to simulate the War Card Game.  It's written with Object-Oriented Programming in mind, user an object for each relevant aspect of the game.

In the interest of extensibility, the War class is based on an interface.  Theoretically, in the future, if we want to implement other card games, this interface can be re-used.  It compels the programmer to decide logic on how each round is dealt, won, etc., which is crucial in any card game.

Back-bone libraries include a card with the appropriate name/color/suit, a card deck that will shuffle cards, etc.  Each card can be decided as face up or face down.  A ToString() operator on each card outputs a description. 

Each War object declaration must include a delegate function that tells the object how to output the outcome of the round.  Included in this project are a delegate to output this information to a console window, and one that handles a graphical interface.

In order to switch between the WarConsole and WarGUI modes, please set the appropriate one as the Start-up project.

TODO: Create unit tests for possible exceptions.

Written by Daniel Cardillo, 8/8/2018