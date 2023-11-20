using MartianRobots.Input;

namespace MartianRobots.AcceptanceTests;

public class InputTests
{
    
    [Fact]
    public void RobotReturnToOriginTest()
    {
        var inputParser = new InputParser();
        inputParser.ReadLine("5 3");
        inputParser.ReadLine("1 1 E");
        inputParser.ReadLine("RFRFRFRF");
        inputParser.ReadLine("3 2 N");
        inputParser.ReadLine("FRRFLLFFRRFLL");
        inputParser.ReadLine("0 3 W");
        inputParser.ReadLine("LLFFFLFLFL");

        var output = inputParser.Output.Split(Environment.NewLine);
        
        Assert.Equal("1 1 E", output[0]);
        Assert.Equal("3 3 N LOST", output[1]);
        Assert.Equal("2 3 S", output[2]);
    }
}