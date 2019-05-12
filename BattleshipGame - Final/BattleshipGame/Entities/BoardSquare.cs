using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class BoardSquare
    {
        public string Rowheader { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public Boolean IsOccupied = false;
        public Mode ShipType = Mode.Empty;

        /// <summary>
        /// Each row of a board is assigned a Row header letter(A to J)
        /// Start index is the position where Ship is placed.
        /// </summary>
        /// <param name="rowHeader"></param>
        /// <param name="pos"></param>
        public BoardSquare(String rowHeader, Int32 indexStart)
        {
            Rowheader = rowHeader;
            Value = rowHeader + indexStart;
            Index = indexStart;          
        }
       
    }
}
