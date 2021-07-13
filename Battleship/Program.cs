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
            
            //int firstCoordinate = random.Next(game.gameBoard.GetLength(0), game.gameBoard.GetLength(9));
            // Console.WriteLine($"testing {firstCoordinate}");

            //game.SetCoordinates(firstColumn, firstRow);
            //for (int i = 0; i < game.gameBoard.GetLength(0); i++)
            //{
            //    for (int j = 0; j < game.gameBoard.GetLength(1); j++)
            //    {
            //        Console.Write(game.gameBoard[i, j]);
            //        int firstRow = random.Next(0, 10);
            //        int firstColumn = random.Next(0, 10);

            //        Console.WriteLine($"the random weird test results {firstRow} and {firstColumn}");


            //    }
            //}




            //foreach (int i in game.gameBoard1)
            //{
            //    Console.Write(i);

            //}
            while (true)
            {
                Console.WriteLine("Welcome to Battleship!");
                Console.WriteLine("Here are the Rules:");
                Console.WriteLine("The game is played on a 10 x 10 grid, vertically from 'A' to 'J' and horizontally from '0' to '10'. An example guess would be 'C8'.");
                Console.WriteLine("Try to sink the ship by guessing from 'A0' to 'J10'. You have 8 shots to fire, let's start!");
                string guess = Console.ReadLine();
                if (string.IsNullOrEmpty(guess))
                {
                    Console.WriteLine("enter between A0 and J10");
                }
                guess = char.ToUpper(guess[0]) + guess.Substring(1);
                Console.WriteLine(guess);
                game.ConvertLetterToNumber(guess);
            }

            
            //player.FireShot(guess);

            
        }
    }
}
