using MartianRobots.Domain;

namespace MartianRobots.Robot;

public class Robot(int x, int y, Orientation orientation)
{
    public Orientation Orientation { get; private set; } = orientation;

    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Command(Command command)
    {
        switch (command)
        {
            case Domain.Command.L:
                Orientation -= 1;
                break;
            case Domain.Command.R:
                Orientation++;
                break;
            case Domain.Command.F:
                switch (Orientation)
                {
                    case Orientation.N:
                        Y++;
                        break;
                    case Orientation.E:
                        X++;
                        break;
                    case Orientation.S:
                        Y--;
                        break;
                    case Orientation.W:
                        X--;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }

        if (Orientation < Orientation.N)
            Orientation = Orientation.W;
        if (Orientation > Orientation.W)
            Orientation = Orientation.N;
    }
}