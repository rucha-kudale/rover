using System;
using System.Collections.Generic;
using System.Text;
using RoboticRoverLib.Classes;
using RoboticRoverLib.Interfaces; 

namespace RoboticRoverLib
{
    /// <summary>
    /// Shows the direction of the rover 
    /// </summary>
    public enum Direction
    {
        N = 90,
        E = 180,
        S = 270,
        W = 360
    }

    public class RoboticRover : Rover, IMovement, IPosition
    {
        /// <summary>
        /// Constructor of the class 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <param name="plateau"></param>
        public RoboticRover(Int32 x, Int32 y, Direction direction)
        {
            PositionX = x;
            PositionY = y;
            RoverDirection = direction;    
        }
        public void Move(int PlateauX, int PlateauY)
        {
            if (RoverDirection == Direction.N && PlateauY > PositionY)
            {
                PositionY++;
            }
            else if (RoverDirection == Direction.E && PlateauX > PositionX)
            {
                PositionX++;
            }
            else if (RoverDirection == Direction.S && PositionY > 0)
            {
                PositionY--;
            }
            else if (RoverDirection == Direction.W && PositionX > 0)
            {
                PositionX--;
            }
        }

        /// <summary>
        /// Get position and direction of the cover at the end of the command
        /// </summary>
        public string GetPosition()
        {
            string roverPosition = string.Format("{0} {1} {2}", PositionX, PositionY,RoverDirection);
        
            return roverPosition;
        }

        /// <summary>
        /// Change the direction of the rover
        /// </summary>
        /// <param name="directionCode"></param>
        public void ChangeDirection(char directionCode, int degree)
        {
            if (directionCode == 'L' || directionCode == 'l')
                RoverDirection = (RoverDirection - degree) < Direction.N ? Direction.W : RoverDirection - degree;
            else if (directionCode == 'R' || directionCode == 'r')
                RoverDirection = (RoverDirection + degree) > Direction.W ? Direction.N : RoverDirection + degree;
        }

        /// <summary>
        /// Process the command string
        /// </summary>
        /// <param name="commandStr"></param>
        public void Command(string commandStr, int PlateauX, int PlateauY)
        {
            foreach (var command in commandStr)
            {
                if (command == 'L' || command == 'R' || command == 'l' || command == 'r')
                    ChangeDirection(command, 90);
                else if (command == 'M' || command == 'm')
                    Move(PlateauX,PlateauY);
            }
        }
    }
}
