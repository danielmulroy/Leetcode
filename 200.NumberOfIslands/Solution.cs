namespace _200.NumberOfIslands;

public class Solution
{
    private static int xLength;
    private static int yLength;
    private static HashSet<Coordinates> visited = new();

    public static int NumIslands(char[][] grid)
    {
        var islandCount = 0;

        xLength = grid[0].Length;
        yLength = grid.Length;

        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                var location = new Coordinates(i, j);
                if (visited.Contains(location)) continue;
                var val = grid[j][i];
                visited.Add(location);
                if (val == '1')
                {
                    FindIsland(location, grid);
                    islandCount++;
                }
            }
        }

        return islandCount;
    }

    private static void FindIsland(Coordinates location, char[][] grid)
    {
        // + x
        if(location.X + 1 != xLength)
        {
            var guess = new Coordinates(location.X + 1, location.Y);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (grid[location.Y][location.X + 1] == '1') FindIsland(guess, grid);
            }
        }

        // - x
        if (location.X - 1 >= 0)
        {
            var guess = new Coordinates(location.X - 1, location.Y);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (grid[location.Y][location.X - 1] == '1') FindIsland(guess, grid);
            }
        }

        // + y
        if (location.Y + 1 != yLength)
        {
            var guess = new Coordinates(location.X, location.Y + 1);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (grid[location.Y + 1][location.X] == '1') FindIsland(guess, grid);
            }
        }

        // - y
        if (location.Y - 1 >= 0)
        {
            var guess = new Coordinates(location.X, location.Y - 1);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (grid[location.Y - 1][location.X] == '1') FindIsland(guess, grid);
            }
        }

    }

    public record Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int x, int y)
        {
            Y = y;
            X = x;
        }
    }
}
