using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        
        public const int HITS = 0;

        public int[,] gameBoard = new int[10, 10]
           {
                {00,01,02,03,04,05,06,07,08,09 },
                {10,11,12,13,14,15,16,17,18,19 },
                {20,21,22,23,24,25,26,27,28,29 },
                {30,31,32,33,34,35,36,37,38,39 },
                {40,41,42,43,44,45,46,47,48,49 },
                {50,51,52,53,54,55,56,57,58,59 },
                {60,61,62,63,64,65,66,67,68,69 },
                {70,71,72,73,74,75,76,77,78,79 },
                {80,81,82,83,84,85,86,87,88,89 },
                {90,91,92,93,94,95,96,97,98,99 }

           };

        public int[,] gameBoard1 = new int[10, 10];

        public int[] shipCoordinates = new int[5]
        {
            00,01,02,03,04
        };

        bool isSunk = false;

        public Game()
        {

        }
        public void SetCoordinates()
        {
            const int ROW_PLACEMENT = 10;
            const int COLUMN_PLACEMENT = 1;
            Random random = new Random();
            int firstColumn = random.Next(0, 10);
            int firstRow = random.Next(0, 10);
            Console.WriteLine($"first column is {firstColumn}");
            Console.WriteLine($"first row is {firstRow}");
            //int firstCoordinate = int.Parse(firstColumn.ToString() + firstRow.ToString());
            //Console.WriteLine($"first coordinates are {firstCoordinate}");
            int[] coordinates = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                
                
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j]);
                    if (firstRow == i && firstColumn == j)
                    {
                        coordinates[0] = gameBoard[i, j];
                        Console.WriteLine(" " + coordinates[0] + "is it working?");
                    }

                }
            }
           
            
            
            int coinFlip = random.Next(2);
            Console.WriteLine($"the coinflip result is {coinFlip}");
            
            if (coinFlip == 0)
            {
                for (int i = 1; i < coordinates.Length; i++)
                {
                    coordinates[i] = firstRow += ROW_PLACEMENT;

                }
                foreach (var item in coordinates)
                {
                    Console.WriteLine(item);
                }
            } else if (coinFlip == 1)
            {
                for (int i = 1; i < coordinates.Length; i++)
                {
                    coordinates[i] = firstColumn += COLUMN_PLACEMENT;
                }
                foreach (var item in coordinates)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void CheckGuess(int guess)
        {
            Console.WriteLine("the guess is " + guess);
            for (int i = 0; i < shipCoordinates.Length; i++)
            {
                if (guess == shipCoordinates[i])
                {
                    Console.WriteLine("hit!");
                } else
                {
                    Console.WriteLine("miss");
                }
            }
        }
        public void ConvertLetterToNumber(string guess)
        {
            char _guess = guess[0];
            char[] letters = new char[]
            {
                'A','B','C','D','E','F','G','H','I','J'
            };
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            for (int i = 0; i < letters.Length; i++)
            {
                if(_guess == letters[i])
                {
                    Console.WriteLine($"you matched {guess} with {letters[i]}");
                    int convertedNumber = numbers[i];
                    //Console.WriteLine($"{letters[i]} is equal to {convertedNumber}");
                    //Console.WriteLine($"original guess is {guess}");
                    guess = $"{numbers[i]}{guess[1]}";
                    int parsedGuess = int.Parse(guess);
                    Console.WriteLine($"guess is now {parsedGuess}");
                    CheckGuess(parsedGuess);
                    return;

                }
                else { Console.WriteLine("no match"); }

            }

            //foreach (var letter in letters)
            //{
            //    if (_guess != letter)
            //        Console.WriteLine("Sorry, you must enter A-J");
            //    else
            //        Console.WriteLine($"ok you matched {_guess} with {letter}");
            //    Console.ReadLine();
            //}
        

        }
        //public int drawShipOnBoard()
        //{

        //}

    }
}
