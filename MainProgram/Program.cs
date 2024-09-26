using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using static System.Console;

namespace MainProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TURNS = 9;

            WriteLine("\n----------------------------------");
            WriteLine("Welcome to tic-tac-toe");
            WriteLine("----------------------------------");
            WriteLine("Players will take turns choosing an unoccupied cell.");
            WriteLine("The first player to get 3 in a row (or column or diagonal) wins!\n");

            char[] board = new char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            // will hold the winning player when there is one
            int winner = 0;

            for (int turn = 0; turn < MAX_TURNS; turn++)
            {
                // player X on even turns, player O on odd turns
                char currentPlayer = turn % 2 == 0 ? 'X' : 'O';
                WriteLine($"currentPlayer={currentPlayer}; turn={turn}");
                WriteLine("Current Board: ");
                DisplayBoard(board);
                board = MakeMove(currentPlayer, board);
                if (HasWinner(board))
                {
                    winner = currentPlayer;
                    break;
                }
            }
            DisplayBoard(board);

            // print the game outcome
            if (winner == 'X')
            {
                WriteLine("\n/----------------\\");
                WriteLine($"|     X wins!    |");
                WriteLine("\\----------------/");                
            }
            else if(winner == 'O')
            {
                WriteLine("\n/----------------\\");
                WriteLine($"|     O wins!    |");
                WriteLine("\\----------------/");
            }
            else
            {
                WriteLine("Looks like a draw");                
            }
        }

        // TODO: write the functions used in main (and any other helper functions you want to use)

        // DisplayBoard
        /**
         * displays the tic-tac-toe board
         * given the contents of the named cells
         *  a | b | c
         * ---+---+---
         *  d | e | f
         * ---+---+--
         *  g | h | i
         */
         //char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

         public static void DisplayBoard(char[] board)
         {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---+---+--");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}");
        
         }

        //GetMove
        /* given a string to prompt the user for input, get a cell.
         * The user must enter a single character, 'a' through 'i', that's it.
         * Verify the cell is valid (e.g. it is in the board, and no one has played there yet).         
         * return the index of the cell the player selected (if they want 'a' you'd return 0)
        */
    
        public static int GetMove(string prompt, char[] board)
        {
            
            while(true)
            {
                Console.WriteLine(prompt);
                string userInputString = Console.ReadLine();
                if(userInputString.Length == 1)
                {
                    char characteUserInput = userInputString[0];
                    if (characteUserInput >= 'a' && characteUserInput <= 'i')
                    {
                        int offset = characteUserInput - 'a';
                        if(board[offset] == characteUserInput)
                        {
                            return offset;
                        }
                    }
                }
            }
        }
        
        //HasWinner
        /* given the board,
         * returns true if the board has a winner (8 possibilities: horizontal, vertical, or diagonal)
         */
        // hint: just return true if you can find three-in-a-row
        // of any character; consider writing the function 'CellsAreTheSame'
        // described below

        public static bool CellsAreTheSame(char a, char b, char c)
        {
            return a == b && b == c;
        }
        
          //returns true if a, b, and c are all the same
         

         /**
         * displays the tic-tac-toe board
         * given the contents of the named cells
         *  a | b | c
         * ---+---+---
         *  d | e | f
         * ---+---+--
         *  g | h | i
         */

        public static bool HasWinner(char[] board)  
        {
            return CellsAreTheSame (board[0], board[1], board[2]) ||
                   CellsAreTheSame (board[3], board[4], board[5]) || 
                   CellsAreTheSame (board[6], board[7], board[8]) ||
                   CellsAreTheSame (board[0], board[3], board[6]) ||
                   CellsAreTheSame (board[1], board[4], board[7]) || 
                   CellsAreTheSame (board[2], board[5], board[8]) ||
                   CellsAreTheSame (board[0], board[4], board[8]) ||
                   CellsAreTheSame (board[2], board[4], board[6]);
        }




        //MakeMove
        /**
         * Call GetMove("Where do you want to play?") until player selects an unused cell.
         * Update the board at that index with the current player's symbol.
         */
        //hint: you'll want to pass in the board so that you can change it; 
        // also, you'll probably have a loop in here in case the user selects a 
        // cell that another player already picked.  You'll need to ask again for them to
        // pick another cell.
        public static char[] MakeMove(char currentPlayer, char[] board)
        {
            var a = GetMove("Where do you want to play?", board);
            board[a] = currentPlayer;
            return board;
        }

    }
}
