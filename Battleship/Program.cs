using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SetShipCoordinates();
            List<char> letters = new List<char>()
            {
                'A','B','C','D','E','F','G','H','I','J'
            };
            Console.WriteLine("Welcome to Battleship!\nHere are the Rules: ");
            Console.WriteLine("The game is played on a 10 x 10 grid, vertically from 'A' to 'J' and horizontally from '0' to '10'.\nAn example guess would be 'C8'.");
            Console.WriteLine("Try to sink the ship by guessing from 'A0' to 'J10'. You have 8 shots to fire, let's start!\n");
            while (!game.isSunk || game.guesses >= 0)
            {
                if (game.isSunk)
                {
                    Console.WriteLine("You sunk my battleship!");
                    return;
                }
                else if (game.guesses == 0)
                {
                    Console.WriteLine("You are out of guesses!\nGame Over");
                    return;
                }

                string guess = Console.ReadLine();
                guess = char.ToUpper(guess[0]) + guess.Substring(1);
                if (string.IsNullOrEmpty(guess) || !letters.Contains(guess[0]))
                {
                    Console.WriteLine("Please enter between A0 and J10\n");
                    
                }
                else
                {
                    game.CheckGuess(guess);
                }
            }
        }
    }
}
