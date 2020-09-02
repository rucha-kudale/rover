using RoboticRoverLib.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboticRoverLib.Interfaces
{
    public interface IMovement
    {
        void Move(int PlateauX, int PlateauY);
        void ChangeDirection(Char directionCode, int degree);
    }
}
