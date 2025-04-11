using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ToyRobotApplication
{
    public class Utilities
    {
        string direction = "NORTH,EAST,SOUTH,WEST";
        string CommandList = "PLACE,MOVE,LEFT,RIGHT,REPORT,EXIT";
        public bool validateInput(string input)
        {
            bool result = false;
            var commandList = CommandList.Split(',').ToList();

            var inputCommand = input.Split(" ");
            if (inputCommand.Length > 0 && commandList.Contains(inputCommand[0].ToUpper()))
            {
                if(inputCommand.Length>1)
                {
                    string[] inputCorrdinates = inputCommand[1].Split(',');
                    if(checkforIntCorr(inputCorrdinates[0]) &&
                                checkforIntCorr(inputCorrdinates[1]) &&
                                checkforDirection(inputCorrdinates[2].ToUpper()))
                        result = true;
                     
                }
                else
                {
                    result = true;
                }
            }
 
            return result;
        }

        private bool checkforIntCorr(string input)
        {
            int value;
            bool result = int.TryParse(input, out value);
            if (value < 0 || value > 4)
                result = false;

            return result;
        }

        private bool checkforDirection(string input)
        {
            bool res = false;
            var directionList = direction.Split(",").ToList();
            if(directionList.Contains(input))
                res = true;
            return res;
        }

    }
}
