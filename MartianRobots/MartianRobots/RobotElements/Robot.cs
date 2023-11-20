using MartianRobots.Domain;

namespace MartianRobots.RobotElements;

public class Robot(MarsGrid marsGrid, int x, int y, Orientation orientation)
{
    public Orientation Orientation { get; private set; } = orientation;

    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;
    public bool IsLost { get; private set; }

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
                MoveForward();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }

        if (Orientation < Orientation.N)
            Orientation = Orientation.W;
        if (Orientation > Orientation.W)
            Orientation = Orientation.N;
    }

    private void MoveForward()
    {
        var nextX = X;
        var nextY = Y;
        switch (Orientation)
        {
            case Orientation.N:
                nextY++;
                break;
            case Orientation.E:
                nextX++;
                break;
            case Orientation.S:
                nextY--;
                break;
            case Orientation.W:
                nextX--;
                break;
        }

        try
        {
            if (marsGrid.HasScent(nextX, nextY))
                return;
            X = nextX;
            Y = nextY;
        }
        catch (IndexOutOfRangeException)
        {
            IsLost = true;
            marsGrid.MarkCell(X, Y);
        }
    }
}