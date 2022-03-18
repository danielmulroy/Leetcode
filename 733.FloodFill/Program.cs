
using _733.FloodFill;

var grid = new int[4][];
grid[0] = new int[5] { 1, 1, 1, 1, 0 };
grid[1] = new int[5] { 1, 1, 0, 1, 0 };
grid[2] = new int[5] { 1, 0, 0, 0, 0 };
grid[3] = new int[5] { 0, 1, 0, 1, 0 };

var newgrid = Solution.FloodFill(grid, 1, 1, 3);

foreach (var arr in grid)
{
    foreach (var i in arr)
    {
        Console.Write(i);
    }
    Console.WriteLine();
}