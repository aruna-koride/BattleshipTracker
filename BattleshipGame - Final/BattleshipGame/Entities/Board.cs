using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Board
    {
        public static char[] Alpha = Globals.AlphaString.ToCharArray();
        public List<BoardSquare> SquareList = new List<BoardSquare>();        
        Int32 shipCount = 0;

        /// <summary>
        /// Creates a new Board with the given size.
        /// Assumption : Board is 10x10 dimension .
        /// </summary>
        /// <param name="intSize"></param>
        public void CreateBoard(Int32 intSize)
        {
            try
            {
                for (int row = 0; row < intSize; row++)
                {
                    string strName = Alpha[row].ToString();

                    for (int col = 0; col < intSize; col++)
                    {
                        BoardSquare square = new BoardSquare(strName, col);
                        SquareList.Add(square);
                    }
                }
                // Print();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Addsthe ship with specified type, position, orientation and size parameters.
        /// Sets the flag for board squares that are occupied by ship. 
        /// Prints the value "##" for board squares that are occupied by ship based on the ship type symbol.
        /// </summary>
        /// <param name="gameShip"></param>
        public void AddShip(Ship gameShip)
        {
            try
            {

                BoardSquare StartBoard = gameShip.Square;
                shipCount++;
                // When ship is placed horizontally.
                if (gameShip.ShipOrientation == Orientation.Horizontal)
                {

                    List<BoardSquare> squares = SquareList.FindAll(item => item.Value.Contains(StartBoard.Rowheader)).ToList();
                    Int32 startIndex = squares.FindIndex(item => item.Value == StartBoard.Value);

                    for (int index = 0; index < gameShip.Size; index++)
                    {
                        squares[index + startIndex].IsOccupied = true;
                        squares[index + startIndex].ShipType = gameShip.ShipType;
                        squares[index + startIndex].Value = Globals.GetShipTypeSymbol(gameShip.ShipType);
                    }

                    Console.WriteLine();
                }
                else
                {
                    // when the ship is placed vertically
                    List<BoardSquare> squares = SquareList.FindAll(item => item.Index == (StartBoard.Index));
                    Int32 startIndex = squares.FindIndex(item => item.Value == StartBoard.Value);


                    for (int index = 0; index < gameShip.Size; index++)
                    {
                        squares[index + startIndex].IsOccupied = true;
                        squares[index + startIndex].ShipType = gameShip.ShipType;
                        squares[index + startIndex].Value = Globals.GetShipTypeSymbol(gameShip.ShipType);
                    }
                    Console.WriteLine();

                }

                Console.WriteLine("\nSuccesfully added " + gameShip.ShipType + "(" + Globals.GetShipTypeSymbol(gameShip.ShipType) + ") at " + StartBoard.Value + " " + gameShip.ShipOrientation + "ly.");

            }
            catch
            {
                Console.WriteLine("\n" + gameShip.ShipType + " doesn't fit in the given position " + gameShip.Square.Value + " as it was already occupied." + " Please adjust the position and try again.");
            }
        }


        /// <summary>
        /// Prints the board to console in different states(NEW, ADD SHIP, WIN)
        /// Assumptions: Each row is named with an alphabet(Ex: A) and value has both name and position(EX:B9).
        /// </summary>
        public void Print()
        {
            try
            {
                String val = "";
                int x = 0;
                int y = 10;
                foreach (var item in SquareList)
                {
                    val = "";
                    if (y > 100)
                    {
                        return;
                    }
                    for (int i = x; i < y; i++)
                    {
                        val += SquareList[i].Value + " ";
                    }
                    x = x + 10;
                    y = y + 10;
                    Console.WriteLine("\n" + val);
                }
            }
            catch
            {
                throw;
            }
        }       

    }
}
