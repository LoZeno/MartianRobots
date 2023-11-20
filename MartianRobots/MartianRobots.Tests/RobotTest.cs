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

    [Theory]
    [InlineData(0, 0, Orientation.N, 0, 1)]
    [InlineData(0, 0, Orientation.E, 1, 0)]
    [InlineData(1, 1, Orientation.S, 1, 0)]
    [InlineData(1, 1, Orientation.W, 0, 1)]
    [InlineData(2, 2, Orientation.N, 2, 3)]
    [InlineData(2, 2, Orientation.E, 3, 2)]
    [InlineData(3, 3, Orientation.S, 3, 2)]
    [InlineData(3, 3, Orientation.W, 2, 3)]
    public void WhenMovingForward_RobotPositionIsOneCellInDirectionOfOrientation(int initialX, int initialY, Orientation initialOrientation, int expectedX, int expectedY)
    {
        var robot = new Robot.Robot(initialX, initialY, initialOrientation);
        
        robot.Command(Command.F);
        
        Assert.Equal(expectedX, robot.X);
        Assert.Equal(expectedY, robot.Y);
    }
}