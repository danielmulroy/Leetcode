
using _200.NumberOfIslands;

//char[][] grid = new char[4][];
//grid[0] = new char[5] { '1', '1', '1', '1', '0' };
//grid[1] = new char[5] { '1', '1', '0', '1', '0' };
//grid[2] = new char[5] { '1', '1', '0', '0', '0' };
//grid[3] = new char[5] { '0', '0', '0', '0', '0' };

char[][] grid = new char[4][];
grid[0] = new char[5] { '1', '1', '1', '1', '0' };
grid[1] = new char[5] { '1', '1', '0', '1', '0' };
grid[2] = new char[5] { '1', '0', '0', '0', '0' };
grid[3] = new char[5] { '0', '1', '0', '1', '0' };


Console.WriteLine(Solution.NumIslands(grid));