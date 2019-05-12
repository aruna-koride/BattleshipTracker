using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    /// <summary>
    /// Assumption: Each Ship Type has a specified Ship size
    /// </summary>
    public enum Mode
    {
        Empty,
        Battleship,
        Cruiser,
        Submarine,
        AircraftCarrier,
        Destroyer,
        Hit,
        Miss
    }

    /// <summary>
    /// Assumption : Only 2 directios
    /// </summary>
    public enum Orientation
    {
        Vertical,
        Horizontal
    }
    
    public class Ship
    {
        public Mode ShipType { get; set; }
        public int Size { get; set; }
        public BoardSquare Square { get; set; }
        public Orientation ShipOrientation { get; set; }

        public Ship(Mode shipType, int size, Orientation orientation)
        {
            ShipType = shipType;
            Size = size;
            ShipOrientation = orientation;
        }
        
    }

}
