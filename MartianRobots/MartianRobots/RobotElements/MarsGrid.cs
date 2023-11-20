namespace MartianRobots.RobotElements;

public class MarsGrid(int maxX, int maxY)
{
    private readonly bool[,] _grid = new bool[maxX+1, maxY+1];

    public bool HasScent(int x, int y, int nextX, int nextY)
    {
        return _grid[x, y] && IsOutOfBound(nextX, nextY);
    }

    public void MarkCell(int x, int y)
    {
        _grid[x, y] = true;
    }

    public bool IsOutOfBound(int x, int y)
    {
        return !(x >= 0 && x < _grid.GetLength(0) && y >= 0 && y < _grid.GetLength(1));
    }
    
}