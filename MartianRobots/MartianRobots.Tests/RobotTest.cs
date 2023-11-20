using MartianRobots.Domain;

namespace MartianRobots.Tests;

public class RobotTest
{
    [Theory]
    [InlineData(Orientation.S, Orientation.E)]
    [InlineData(Orientation.E, Orientation.N)]
    [InlineData(Orientation.W, Orientation.S)]
    [InlineData(Orientation.N, Orientation.W)]
    public void WhenTurningLeft_OrientationIs90DegreesLeft(Orientation initialOrientation, Orientation expectedOrientation)
    {
        var robot = new Robot.Robot(0, 0, initialOrientation);

        robot.Command(Command.L);
        
        Assert.Equal(expectedOrientation, robot.Orientation);
    }
    
    [Theory]
    [InlineData(Orientation.S, Orientation.W)]
    [InlineData(Orientation.E, Orientation.S)]
    [InlineData(Orientation.W, Orientation.N)]
    [InlineData(Orientation.N, Orientation.E)]
    public void WhenTurningRight_OrientationIs90DegreesRight(Orientation initialOrientation, Orientation expectedOrientation)
    {
        var robot = new Robot.Robot(0, 0, initialOrientation);

        robot.Command(Command.R);
        
        Assert.Equal(expectedOrientation, robot.Orientation);
    }
}