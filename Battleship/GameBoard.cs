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
        List<int> hitCoordinates = new List<int>();


        

        public Game()
        {

        }
        public void SetCoordinates()
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
                        //Console.Write(GAME_BOARD[i, j]);
                        if (firstRow == i && firstColumn == j)
                        {
                            shipCoordinates[0] = GAME_BOARD[i, j];
                            //Console.WriteLine(" " + shipCoordinates[0] + " is it working?");
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
                        //Console.Write(GAME_BOARD[i, j]);
                        if (firstRow == i && firstColumn == j)
                        {
                            shipCoordinates[0] = GAME_BOARD[i, j];
                            //Console.WriteLine(" " + shipCoordinates[0] + " is it working?");
                        }

                    }
                }
                for (int i = 1; i < shipCoordinates.Length; i++)
                {
                   

                    shipCoordinates[i] = shipCoordinates[i - 1] + COLUMN_PLACEMENT;
                }
                
            }
            foreach (var item in shipCoordinates)
            {
                Console.WriteLine(item);
            }
        }

        public void CheckGuess(int guess)
        {
            Console.WriteLine("the guess is " + guess);
            if (CheckHitList(guess))
            {
                return;
            }
            
            foreach (var coordinate in shipCoordinates)
            {
                if (guess == coordinate)
                {
                    Console.WriteLine("hit!");
                    hitCoordinates.Add(guess);
                    hits++;
                    guesses--;
                    Console.WriteLine($"GUESSES LEFT {guesses}");
                    if (hits == 5)
                    {
                        isSunk = true;
                    }
                    return;
                }
            }
            Console.WriteLine("miss!");
            guesses--;
            Console.WriteLine($"GUESSES LEFT {guesses}");
        }

        public bool CheckHitList(int guess)
        {
            //bool isHit = false;
            foreach (var coordinate in hitCoordinates)
            {
                if (guess == coordinate)
                {
                    Console.WriteLine("you already guessed this");
                    return true;
                }
          
            }
            return false;
        }
        public void ConvertLetterToNumber(string guess)
        {
            char _guess = guess[0];
            char[] letters = new char[]
            {
                'A','B','C','D','E','F','G','H','I','J'
            };
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            for (int i = 0; i < letters.Length; i++)
            {
                if(_guess == letters[i])
                {
                    Console.WriteLine($"you matched {guess} with {letters[i]}");
                   // int convertedNumber = numbers[i];
                    guess = $"{numbers[i]}{guess[1]}";
                    int parsedGuess = int.Parse(guess);
                    Console.WriteLine($"guess is now {parsedGuess}");
                    CheckGuess(parsedGuess);
                    return;

                }
               

            }

         
        

        }
      

    }
}
