using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboticRoverLib;
using RoboticRoverLib.Classes;
namespace RoboticRoverMarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter maximum coordinates of plateau (x, y): ");
            string coordinates=  Console.ReadLine();
            string[] cor = coordinates.Split(',').ToArray();
            int x=0, y=0,num=0;
            if (cor.Length == 2)
            {
                x = Convert.ToInt16(cor[0].Trim());
                y = Convert.ToInt16(cor[1].Trim());
            }
            Console.WriteLine("Please enter number of rovers on plateau : ");
            string numberOfRovers = Console.ReadLine();
            if(!string.IsNullOrEmpty(numberOfRovers))
            {
                num= Convert.ToInt16(numberOfRovers.Trim());               
            }
            Plateau p = new Plateau(x,y);
            int xRover = 0, yRover = 0;
            bool notValidCords = true;
            string[] corRover = new string[3];
            for (int i = 0; i < num; i++)
            {
                notValidCords = true;
                while (notValidCords)
                {
                    Console.WriteLine(string.Format("Please enter starting coordinates and facing of rover{0} (x y facing): ", i + 1));
                    string coor = Console.ReadLine();
                    corRover = coor.Split(' ').ToArray();
                    xRover = Convert.ToInt16(corRover[0].Trim());
                    yRover = Convert.ToInt16(corRover[1].Trim());
                    if (0 <= xRover && xRover <= x && yRover >= 0 && yRover <= y)
                    {
                        notValidCords = false;
                        break;
                    }
                    else Console.WriteLine("Invalid Coordinates!");
                }
                Direction c = Direction.N;
                switch (corRover[2].Trim().ToUpper())
                {
                    case "N":
                        c = Direction.N;
                        break;
                    case "W":
                        c = Direction.W;
                        break;
                    case "S":
                        c = Direction.S;
                        break;
                    case "E":
                        c = Direction.E;
                        break;
                   default:
                        c = Direction.N;
                        break;
                }
                RoboticRover rover = new RoboticRover(xRover,yRover,c);
                Console.WriteLine(string.Format("Please enter command for rover{0}",i+1));
                string command = Console.ReadLine();
                rover.Command(command.Trim(), x, y);
                p.Rovers.Add(rover);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Final position of Rovers respectively: ");
            foreach (var rover in p.Rovers)
            {
                Console.WriteLine(rover.GetPosition());
            }
            Console.ReadLine();
        }
    }
}
