using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApplication
{
    public class CommandCentre
    {
        ToyRobot objToyRobot = new ToyRobot();

        public void Run()
        {
            string command = "";
            Utilities util = new Utilities();
            Console.WriteLine("PLease enter your command to move the Toy Robot: PLACE X,Y,Dir | MOVE | LEFT | RIGHT | REPORT)");
            do
            {
                command = Console.ReadLine();
                if (util.validateInput(command))
                {
                    executeCommand(command);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }

            } while (command.ToUpper() != "EXIT");

        }

        private void executeCommand(string input)
        {
            string[] inputCmds = input.Split(" ");

            switch (inputCmds[0].ToUpper())
            {
                case "PLACE":
                    objToyRobot.PLACE(inputCmds[1].Split(','));
                    break;
                case "MOVE":
                    objToyRobot.MOVE();
                    break;
                case "LEFT":
                    objToyRobot.LEFT();
                    break;
                case "RIGHT":
                    objToyRobot.RIGHT();
                    break;
                case "REPORT":
                    objToyRobot.REPORT();
                    break;
            }
        }
    }
}
