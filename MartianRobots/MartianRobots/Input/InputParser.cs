using MartianRobots.Domain;
using MartianRobots.RobotElements;

namespace MartianRobots.Input;

public class InputParser
{
    private MarsGrid? _grid;
    private Robot? _robot;

    public string Output { get; private set; }

    public void ReadLine(string input)
    {
        if (_grid == null)
        {
            var gridSizeCommand = input.Split(' ');
            var width = int.Parse(gridSizeCommand[0]);
            var height = int.Parse(gridSizeCommand[1]);
            _grid = new MarsGrid(width, height);
        }
        else if (_robot == null)
        {
            var initialPosition = input.Split(' ');
            var initialX = int.Parse(initialPosition[0]);
            var initialY = int.Parse(initialPosition[1]);
            var initialOrientation = Enum.Parse<Orientation>(initialPosition[2]);
            _robot = new Robot(_grid, initialX, initialY, initialOrientation);
        }
        else
        {
            foreach (var command in input)
            {
                _robot.Command(Enum.Parse<Command>(command.ToString()));
            }

            Output = $"{_robot.X} {_robot.Y} {_robot.Orientation}";
            _robot = null;
        }
    }
}