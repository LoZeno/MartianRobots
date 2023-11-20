namespace MartianRobots.RobotElements;

public class MarsGrid(int maxX, int maxY)
{
    private readonly bool[,] _grid = new bool[maxX+1, maxY+1];

    public bool HasScent(int x, int y)
    {
        return _grid[x, y];
    }

    public void MarkCell(int x, int y)
    {
        _grid[x, y] = true;
    }
}