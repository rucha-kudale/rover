using System;
using System.Collections.Generic;
using System.Text;

namespace RoboticRoverLib.Classes
{
    public class Plateau
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<RoboticRover> Rovers; 

        /// <summary>
        /// Width and height of the Plateau, and list of rovers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Plateau(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
            Rovers = new List<RoboticRover>();
        }
    }
}
