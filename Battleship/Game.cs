using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        
        public int hits = 0;
        public int guesses = 8;
        public bool isSunk = false;

        public int[,] GAME_BOARD = new int[10, 10]
           {
                {10,11,12,13,14,15,16,17,18,19 },
                {20,21,22,23,24,25,26,27,28,29 },
                {30,31,32,33,34,35,36,37,38,39 },
                {40,41,42,43,44,45,46,47,48,49 },
                {50,51,52,53,54,55,56,57,58,59 },
                {60,61,62,63,64,65,66,67,68,69 },
                {70,71,72,73,74,75,76,77,78,79 },
                {80,81,82,83,84,85,86,87,88,89 },
                {90,91,92,93,94,95,96,97,98,99 },
                {100,101,102,103,104,105,106,107,108,109 }

           };
        int[] shipCoordinates = new int[5];
        char[] letters = new char[]
            {
                'A','B','C','D','E','F','G','H','I','J'
            };

        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<string> hitCoordinates = new List<string>();
        List<string> missedCoordinates = new List<string>();

        public void SetShipCoordinates()
        {
            const int ROW_PLACEMENT = 10;
            const int COLUMN_PLACEMENT = 1;
            Random random = new Random();
            int firstRow;
            int firstColumn;
            int coinFlip = random.Next(2);
          

            if (coinFlip == 0)
            {
               
                firstRow = random.Next(0, 6);
                firstColumn = random.Next(0, 10);

                for (int i = 0; i < GAME_BOARD.GetLength(0); i++)
                {


                    for (int j = 0; j < GAME_BOARD.GetLength(1); j++)
                    {
                        if (firstRow == i && firstColumn == j)
                        {
                            shipCoordinates[0] = GAME_BOARD[i, j];
                        }

                    }
                }
                for (int i = 1; i < shipCoordinates.Length; i++)
                {
                    
                    shipCoordinates[i] = shipCoordinates[i - 1] + ROW_PLACEMENT;

                }
                
            } else if (coinFlip == 1)
            {
                firstRow = random.Next(0, 10);
                firstColumn = random.Next(0, 6);
                for (int i = 0; i < GAME_BOARD.GetLength(0); i++)
                {


                    for (int j = 0; j < GAME_BOARD.GetLength(1); j++)
                    {
                        if (firstRow == i && firstColumn == j)
                        {
                            shipCoordinates[0] = GAME_BOARD[i, j];
                        }

                    }
                }
                for (int i = 1; i < shipCoordinates.Length; i++)
                {
                    shipCoordinates[i] = shipCoordinates[i - 1] + COLUMN_PLACEMENT;
                }

            }
        }

        public void CheckGuess(string guess)
        {
            
            int parsedGuess = ConvertLetterToNumber(guess);
            foreach (var coordinate in shipCoordinates)
            {
                if (parsedGuess == coordinate)
                {
                    Console.WriteLine("HIT!\n");
                    hitCoordinates.Add(guess);
                    hits++;
                    guesses--;
                    DisplayHitsAndMisses();
                    Console.WriteLine($"GUESSES LEFT: {guesses}\n");
                    if (hits == 5)
                    {
                        isSunk = true;
                    }
                    return;
                }
            }
            Console.WriteLine("MISS!\n");
            missedCoordinates.Add(guess);
            DisplayHitsAndMisses();
            guesses--;
            Console.WriteLine($"GUESSES LEFT: {guesses}\n");
        }

       
        public int ConvertLetterToNumber(string guess)
        {
            char firstLetter = guess[0];
            int parsedGuess;

            for (int i = 0; i < letters.Length; i++)
            {
                if(firstLetter == letters[i])
                {
                    guess = $"{numbers[i]}{guess[1]}";
                    parsedGuess = int.Parse(guess);
                    return parsedGuess;

                } 
            }
            return 0;
        }

        public void DisplayHitsAndMisses()
        {
            Console.WriteLine($"HITS: {string.Join(", ", hitCoordinates)}");
            Console.WriteLine($"MISSES: {string.Join(", ", missedCoordinates)}");
        }
    }
}
