using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace _723.CandyCrush;

public class Solution
{
    public static int[][] CandyCrush(int[][] board)
    {
        while (true)
        {
            if (!DoCrush(ref board)) break;
        }
    }

    private static bool DoCrush(ref int[][] board)
    {
        var visited = new HashSet<(int, int)>();
        var deletion = new 
        var coordinates = (0, 0);

        var val = board[0][0];
        var count = 1;
        CheckNeighbours(val, ref count, coordinates, ref board, ref visited);
    }

    private static void CheckNeighbours(int prevVal, ref int count, (int i, int j) coordinates, ref int[][] board, ref HashSet<(int, int)> visited)
    {
        if (visited.Contains(coordinates)) return;

        visited.Add(coordinates);

        var 
        
    }
}