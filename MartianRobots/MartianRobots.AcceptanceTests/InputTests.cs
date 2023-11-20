using MartianRobots.Input;

namespace MartianRobots.AcceptanceTests;

public class InputTests
{
    private readonly InputParser _inputParser;

    public InputTests()
    {
        _inputParser = new InputParser();
        _inputParser.ReadLine("5 3");
    }
    
    [Fact]
    public void RobotReturnToOriginTest()
    {

        _inputParser.ReadLine("1 1 E");
        _inputParser.ReadLine("RFRFRFRF");
        
        Assert.Equal("1 1 E", _inputParser.Output);
    }
    
    [Fact]
    public void RobotLostTest()
    {
        _inputParser.ReadLine("3 2 N");
        _inputParser.ReadLine("FRRFLLFFRRFLL");
        
        Assert.Equal("3 3 N LOST", _inputParser.Output);
    }
    
    [Fact]
    public void RobotFinalDestinationTest()
    {
        _inputParser.ReadLine("0 3 W");
        _inputParser.ReadLine("LLFFFLFLFL");
        
        Assert.Equal("2 3 S", _inputParser.Output);
    }
}