using System;
using Xunit;
using RoboticRoverLib;
using RoboticRoverLib.Classes;
using RoboticRoverLib.Interfaces;

namespace RoboticRoverTests
{
    public class RoverUnitTest1
    {
        private RoboticRover Rover = null;

        /// <summary>
        /// Set the first roboticRover
        /// </summary>
        private void SetupRover(int x, int y, Direction dir)
        {
            Rover = new RoboticRover(x, y, dir);
        }

       [Fact]
        public void MoveRover()
        {
            SetupRover(1, 2, Direction.N);
            Rover.Command("LMLMLMLMM",5,5);
            Assert.Equal("1 3 N",Rover.GetPosition());
        }

       [Fact]
        public void MoveRoverRandomly()
        {
            SetupRover(3, 3, Direction.E);
            Rover.Command("MMRMMRMRRM",5,5);
            Assert.Equal("5 1 E",Rover.GetPosition());
        }

       [Fact]
        public void CheckForXBoundry()
        {
            SetupRover(3, 3, Direction.E);
            Rover.Command("MMMMMMMMMM",5,5);
            Assert.Equal("5 3 E",Rover.GetPosition());
        }

       [Fact]
        public void CheckForYBoundry()
        {
            SetupRover(2, 2, Direction.N);
            Rover.Command("MMMMMMMMMM",5,5);
            Assert.Equal("2 5 N",Rover.GetPosition());
        }
        [Fact]
        public void CheckForNegativeBoundry()
        {
            SetupRover(0, 3, Direction.N);
            Rover.Command("LMLMLMLMM", 5, 5);
            Assert.Equal("1 4 N", Rover.GetPosition());
        }

    }
}
