using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace _723.CandyCrush;

public class Solution
{
    public static int[][] CandyCrush(int[][] board)
    {
        var xlength = board.Length;
        var ylength = board[0].Length;
        
        while (true)
        {
            var crushed = new HashSet<Coordinates>();

            //check rows
            for (var i = 0; i < xlength; i++)
            {
                var start = 0;

                while (start < ylength)
                {
                    if (board[i][start] == 0)
                    {
                        start++;
                        continue;
                    }

                    var end = start;
                    while (end < ylength && board[i][end] == board[i][start])
                        end++;

                    if (end - start >= 3)
                    {
                        for (var j = start; j < end; j++)
                        {
                            crushed.Add(new Coordinates(i, j));
                        }
                    }

                    start = end;
                }
            }


            //check columns
            for (var i = 0; i < ylength; i++)
            {
                var start = 0;

                while (start < xlength)
                {
                    if (board[start][i] == 0)
                    {
                        start++;
                        continue;
                    }

                    var end = start;
                    while (end < xlength && board[end][i] == board[start][i])
                    {
                        end++;
                    }

                    if (end - start >= 3)
                    {
                        for (var j = start; j < end; j++)
                        {
                            crushed.Add(new Coordinates(j, i));
                        }
                    }

                    start = end;
                }

            }

            if (crushed.Count == 0)
            {
                break;
            }

            //set zeroes
            foreach (var cell in crushed)
            {
                board[cell.X][cell.Y] = 0;
            }

            for (var i = 0; i < ylength; i++)
            {
                var start = xlength - 1;

                while (start >= 0 && board[start][i] != 0)
                {
                    start--;
                }

                var end = start;
                while (end >= 0 && board[end][i] == board[start][i])
                    end--;
                
                var step = start - end;
                if (step == 0)
                    continue;
                
                var j = end;
                var bottomPlace = end + step;
                while (j >= 0)
                {
                    if (board[j][i] == 0)
                    {
                        j--;
                        continue;
                    }

                    board[bottomPlace][i] = board[j][i];
                    board[j][i] = 0;
                    j--;
                    bottomPlace--;
                }
            }
        }

        return board;
    }
    
    private record struct Coordinates(int X, int Y);
}