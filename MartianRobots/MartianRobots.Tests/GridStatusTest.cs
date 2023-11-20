using MartianRobots.Robot;

namespace MartianRobots.Tests;

public class GridStatusTest
{
    [Fact]
    public void WhenGridIsInitialised_AllCellsHaveNoScent()
    {
        var grid = new MarsGrid(5, 6);
        var cellsScent = new List<(int x, int y, bool hasScent)>();
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 6; j++)
            {
                cellsScent.Add((i, j, grid.HasScent(i, j)));
            }
        }
        
        Assert.All(cellsScent, cell => Assert.False(cell.hasScent, $"Coordinate: {cell.x},{cell.y}"));
    }

    [Fact]
    public void WhenCellIsMarkedWithScent_ReturnsTrue()
    {
        var grid = new MarsGrid(5, 6);
        grid.MarkCell(2, 3);
        
        Assert.True(grid.HasScent(2, 3));
    }
}