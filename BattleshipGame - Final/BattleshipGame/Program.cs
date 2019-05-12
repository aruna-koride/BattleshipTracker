using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ConsoleApp1.Entities;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Testing Battleship program        
        /// </summary>
        public static void Main()
        {
            try
            {
                do
                {
                    Console.WriteLine("Welcome to Battleship game. Press Enter to start the game.");
                    Console.ReadKey();

                    // Create Player
                    Player _Player = new Player(Globals.PlayerName);

                    // Create Board
                    _Player.CreateBoard(Globals.BOARDSIZE);
                    Board GameBoard = _Player.GameBoard;

                   
                    //Add Battleship
                    Ship battleship = new Ship(Mode.Battleship, 4, Orientation.Horizontal);
                    battleship.Square = new BoardSquare("F", Globals.GetRandomNumber(battleship));
                    _Player.AddShip(battleship);
                    

                    //Print the output to console.
                    Console.WriteLine("\nPrinted Output below:\n");
                    Console.WriteLine("*******************************************");
                    GameBoard.Print();
                    Console.WriteLine("*******************************************");

                    // Take the Attack                           
                    do
                    {
                        String rowHeader = "F";
                        Int32 indexStart = Globals.GetRandomNumber();

                        Console.WriteLine("\nPress enter to receive an Attack!");
                        Console.ReadKey();                      
                        
                        _Player.ReceiveAttack(rowHeader, indexStart);

                       // Return the result whether Player has Lost 
                        if (_Player.HasLost())
                        {
                            Console.WriteLine("You have lost the game. All your ships have sunk!");
                            break;
                        }

                    } while (true);

                    Console.WriteLine();
                } while (true);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }       

    }

}

