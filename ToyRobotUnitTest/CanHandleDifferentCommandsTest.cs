using ToyRobotApplication;

namespace ToyRobotUnitTest
{
    [TestClass]
    public sealed class CanHandleDifferentCommandsTest
    {
        [TestMethod]
        public void TestChangeToyRobotDirection()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE 2,3,NORTH";
            var strCmd = cmd.Split(" ");
            objToy.PLACE(strCmd[1].Split(","));
            objToy.MOVE();
            objToy.LEFT();

            Assert.AreEqual(true, (objToy.robotXposition == 2 && objToy.robotYposition == 4 && objToy.robotDirection == "WEST"));
        }


        [TestMethod]
        public void TestPlacingToyOutSideOfBoard()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE 6,6,NORTH";
            objToy.PLACE(cmd.Split(" ")[1].Split(","));

            Assert.AreEqual(true, (objToy.robotXposition == null && objToy.robotYposition == null));
        }

        [TestMethod]
        public void TestCommandFormat()
        {
            Utilities utilities = new Utilities();
            string cmd = "place 2,2,3";
 
            Assert.AreEqual(false, utilities.validateInput(cmd));
        }

        [TestMethod]
        public void TestMultipleCommands()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE 2,2,NORTH";
            objToy.PLACE(cmd.Split(" ")[1].Split(","));
            objToy.MOVE();
            objToy.MOVE();
            objToy.LEFT();
            objToy.MOVE();
            objToy.RIGHT();
            objToy.RIGHT();

            Assert.AreEqual(true, (objToy.robotXposition == 1 && objToy.robotYposition == 4 && objToy.robotDirection == "EAST"));
        }
    }
}
