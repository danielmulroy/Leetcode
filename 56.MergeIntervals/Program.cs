
using _56.MergeIntervals;

var result = Solution.Merge(new[] { new[] { 1, 3 }, new[] { 0, 2 }, new[] { 3, 5 } });

foreach (var i in result)
{
    Console.WriteLine($"({i[0]},{i[1]})");
}

