using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Game game = new Game();
            game.SetCoordinates();

           
            Console.WriteLine("Welcome to Battleship!\nHere are the Rules: ");
            Console.WriteLine("The game is played on a 10 x 10 grid, vertically from 'A' to 'J' and horizontally from '0' to '10'. An example guess would be 'C8'.");
            Console.WriteLine("Try to sink the ship by guessing from 'A0' to 'J10'. You have 8 shots to fire, let's start!");
            while (!game.isSunk || game.guesses >= 0)
            {
                if (game.isSunk)
                {
                    Console.WriteLine("You sunk my battleship!");
                    return;
                }
                else if (game.guesses == 0)
                {
                    Console.WriteLine("You are out of guesses\nGame Over");
                    return;
                }

                string guess = Console.ReadLine();
                guess = char.ToUpper(guess[0]) + guess.Substring(1);
                if (string.IsNullOrEmpty(guess))
                {
                    Console.WriteLine("enter between A0 and J10");
                }
                
                Console.WriteLine(guess);
                game.ConvertLetterToNumber(guess);
            }

            

            
            //player.FireShot(guess);

            
        }
    }
}
