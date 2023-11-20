namespace MartianRobots.Robot;

public class MarsGrid(int width, int height)
{
    private readonly bool[,] _grid = new bool[width, height];

    public bool HasScent(int x, int y)
    {
        return _grid[x, y];
    }

    public void MarkCell(int x, int y)
    {
        _grid[x, y] = true;
    }
}