using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Globals
    {
        public static Int32 BOARDSIZE = 10;
        public static String PlayerName = "ARUNA";
        public static String  AlphaString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        /// <summary>
        /// Random row header position  generation.
        /// </summary>
        /// <param name="ship"></param>
        /// <returns></returns>
        public static String GetRandomAlphabet(Ship ship =null)
        {
            String input = AlphaString;
            // Do some basic null-checking
            if (input == null)
            {
                return Char.MinValue.ToString(); // Or throw an exception or, or, or...
            }

            var random = new Random();
            var inputAsCharArray = input.ToCharArray();
            Int32 index = 0;

            // Ensure that the generated random alphabet coordinates fits the ship size.
            if (ship!=null && ship.ShipOrientation == Orientation.Vertical)
            {
                do
                {
                    index = random.Next(0, 10);
                } while (Globals.BOARDSIZE - index < ship.Size);
            }
            else
            {
                index = random.Next(0, 10);
            }         

            return inputAsCharArray[index].ToString();
        }

        /// <summary>
        /// Random grid square position generation.
        /// </summary>
        /// <param name="ship"></param>
        /// <returns></returns>
        public static Int32 GetRandomNumber(Ship ship = null)
        {
            Random random = new Random();
            Int32 index = 0;

            // Ensure that the generated random number coordinates fits the ship size.
            if (ship!= null && ship.ShipOrientation == Orientation.Horizontal)
            {
                do
                {
                    index = random.Next(0, 10);
                } while (Globals.BOARDSIZE - index < ship.Size);
            }
            else
            {
                index = random.Next(0, 10);
            }
            return index;
        }

        /// <summary>
        /// To assign the symbol for occupied ship positions in the output.
        /// </summary>
        /// <param name="strShipType"></param>
        /// <returns></returns>
        public static String GetShipTypeSymbol(Mode strShipType)
        {
            String strResult = "";
            switch (strShipType)
            {
                case Mode.AircraftCarrier:
                    strResult = "@@";
                    break;

                case Mode.Battleship:
                    strResult = "##";
                    break;

                case Mode.Cruiser:
                    strResult = "&&";
                    break;

                case Mode.Destroyer:
                    strResult = "**";
                    break;

                case Mode.Submarine:
                    strResult = "++";
                    break;

                case Mode.Hit:
                    strResult = "HH";
                    break;

                case Mode.Miss:
                    strResult = "MM";
                    break;

            }
            return strResult;

        }
    }
}
