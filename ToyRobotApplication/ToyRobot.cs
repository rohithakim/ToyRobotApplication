using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApplication
{
    public class ToyRobot
    {
        int xMax = 4;
        int yMax = 4;

        int xMin = 0;
        int yMin = 0;

        public int? robotXposition = null;
        public int? robotYposition = null;
        public string robotDirection = "";

        public void PLACE(string[] inpcmds)
        {
            int x, y;
            string dir = "";
            if (inpcmds.Length == 3)
            {
                x = Convert.ToInt16(inpcmds[0]);
                y = Convert.ToInt16(inpcmds[1]);
                dir = inpcmds[2].ToUpper();
            }
            else
            {

                Console.WriteLine("PLACE command should have both coordinates and direction.");
                return;
            }
             

            if ((x < xMin || x > xMax) || (y < yMin || y > yMax))
            {
                Console.WriteLine("Kindly place the robot inside 5X5 board.");
                return;
            }

            if (x >= xMin && x <= xMax)
                robotXposition = x;

            if (y >= yMin && y <= yMax)
                robotYposition = y;

            if(dir != "")
                robotDirection = dir;

        }

        public void MOVE()
        {
            if (robotXposition != null && robotYposition != null)
            {
                switch (robotDirection.ToUpper())
                {
                    case "NORTH":
                        if (robotYposition <= yMax)
                            robotYposition = robotYposition + 1;
                        break;
                    case "SOUTH":
                        if (robotYposition > 0)
                            robotYposition = robotYposition - 1;
                        break;
                    case "EAST":
                        if (robotXposition <= xMax)
                            robotXposition = robotXposition + 1;
                        break;
                    case "WEST":
                        if (robotXposition > 0)
                            robotXposition = robotXposition - 1;
                        break;
                }
            }
            else
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
        }

        public void LEFT()
        {
            if (robotDirection == "")
            {
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
                return;
            }

            switch (robotDirection.ToUpper())
            {
                case "NORTH":
                    robotDirection = "WEST";
                    break;
                case "SOUTH":
                    robotDirection = "EAST";
                    break;
                case "EAST":
                    robotDirection = "NORTH";
                    break;
                case "WEST":
                    robotDirection = "SOUTH";
                    break;
            }
        }


        public void RIGHT()
        {

            if (robotDirection == "")
            {
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
                return;
            }

            switch (robotDirection.ToUpper())
            {
                case "NORTH":
                    robotDirection = "EAST";
                    break;
                case "SOUTH":
                    robotDirection = "WEST";
                    break;
                case "EAST":
                    robotDirection = "SOUTH";
                    break;
                case "WEST":
                    robotDirection = "NORTH";
                    break;
            }

        }

        public void REPORT()
        {
            Console.WriteLine(string.Concat("Output: ",
                                robotXposition.ToString(), ",",
                                robotYposition.ToString(), ",",
                                robotDirection.ToUpper()));
                                        
        }

    }
}