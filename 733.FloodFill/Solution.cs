namespace _733.FloodFill;

public class Solution
{
    private static int newCol; 
    private static int oldCol;
    private static int xLength;
    private static int yLength;
    private static HashSet<Coordinates> visited = new();

    public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        xLength = image[0].Length;
        yLength = image.Length;
        newCol = newColor;
        oldCol = image[sr][sc];

        PaintIsland(new Coordinates(sc, sr), ref image);

        return image;
    }

    private static void PaintIsland(Coordinates location, ref int[][] image)
    {
        // + x
        if(location.X + 1 != xLength)
        {
            var guess = new Coordinates(location.X + 1, location.Y);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (image[location.Y][location.X + 1] == oldCol) PaintIsland(guess, ref image);
            }
        }

        // - x
        if (location.X - 1 >= 0)
        {
            var guess = new Coordinates(location.X - 1, location.Y);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (image[location.Y][location.X - 1] == oldCol) PaintIsland(guess, ref image);
            }
        }

        // + y
        if (location.Y + 1 != yLength)
        {
            var guess = new Coordinates(location.X, location.Y + 1);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (image[location.Y + 1][location.X] == oldCol) PaintIsland(guess, ref image);
            }
        }

        // - y
        if (location.Y - 1 >= 0)
        {
            var guess = new Coordinates(location.X, location.Y - 1);
            if (!visited.Contains(guess))
            {
                visited.Add(guess);
                if (image[location.Y - 1][location.X] == oldCol) PaintIsland(guess, ref image);
            }
        }

        image[location.Y][location.X] = newCol;
    }

    public record Coordinates(int X, int Y)
    {
        public int X = X;
        public int Y = Y;
    }
}
