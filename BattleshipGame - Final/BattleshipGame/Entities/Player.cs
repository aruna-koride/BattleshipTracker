using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Player
    {
        public String Name { get; set; }
        public Board GameBoard { get; set; }
        public List<BoardSquare> HitList = new List<BoardSquare>();

        public Player(String name)
        {
            Name = name;
            GameBoard = new Board();
          
        }            

        /// <summary>
        /// Creates a new Board with the given size.
        /// Assumption : Board is 10x10 dimension and always a Square .
        /// </summary>
        /// <param name="intSize"></param>
        public void CreateBoard(Int32 intSize)
        {
            try
            {
                GameBoard.CreateBoard(intSize);                
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Adds the ship with specified type, position,orientation and size parameters.
        /// Sets the flag for board squares that are occupied by ship. 
        /// Prints the value "XX" for board squares that are occupied by ship based on the ship type symbol.
        /// </summary>
        /// <param name="gameShip"></param>
        public void AddShip(Ship gameShip)
        {
            try
            {                
                GameBoard.AddShip(gameShip);               
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        ///  /// Returns Hit or Miss when receives the attacks.
        /// </summary>
        /// <param name="rowHeader"></param>
        /// <param name="indexStart"></param>
        public void ReceiveAttack(String rowHeader, Int32 indexStart)
        {
            // Update the Player board with occupied ship spaces            
            BoardSquare targetSquare = this.GameBoard.SquareList.Find(item => item.Rowheader == rowHeader && item.Index == indexStart);

            if (ProcessAttack(targetSquare))
            {
                targetSquare.Value = Globals.GetShipTypeSymbol(Mode.Hit);
                Console.WriteLine("\nIt was a Hit!");             
                        
            }
            else
            {
                targetSquare.Value = Globals.GetShipTypeSymbol(Mode.Miss);
                Console.WriteLine("\nIt was a Miss!");
            }                   

        }
             
        
        /// <summary>
        /// Sets the flag for the occupied squares.
        /// <param name="square"></param>
        /// <returns> </returns>
        public Boolean ProcessAttack(BoardSquare targetSquare)
        {
            try
            {           
                if (targetSquare != null)
                {
                    Console.WriteLine("\nYou received an attack at " + targetSquare.Rowheader + targetSquare.Index);
                    if (targetSquare.IsOccupied)
                    {                       
                        if (HitList.Find(item => item.Rowheader == targetSquare.Rowheader && item.Index == targetSquare.Index) == null)
                        {                         
                            HitList.Add(targetSquare);                            
                        }
                        else
                        {
                            Console.WriteLine("\nThis position was already Hit "+targetSquare.Rowheader+ targetSquare.Index+");
                            return false;
                        }
                    }
                  return  targetSquare.IsOccupied;
                }

                return false;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Returns Player "Lost" when all the ships are sunk(i.e; all the target squares are hit).
        /// </summary>
        /// <returns></returns>
        public Boolean HasLost()
        {
            try
            {
                Int32 OccupiedCount = GameBoard.SquareList.FindAll(item => item.IsOccupied).ToList().Count;

                if (OccupiedCount > 0 && OccupiedCount == HitList.Count)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }

        }
    }
}
