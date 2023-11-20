using MartianRobots.Domain;

namespace MartianRobots.Robot;

public class Robot
{
    private Orientation _orientation;

    public Robot(int x, int y, Orientation orientation)
    {
        _orientation = orientation;
    }

    public Orientation Orientation => _orientation;

    public void Command(Command command)
    {
        switch (command)
        {
            case Domain.Command.L:
                _orientation -= 1;
                break;
            case Domain.Command.R:
                _orientation++;
                break;
            case Domain.Command.F:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }

        if (_orientation < Orientation.N)
            _orientation = Orientation.W;
        if (_orientation > Orientation.W)
            _orientation = Orientation.N;
    }
}