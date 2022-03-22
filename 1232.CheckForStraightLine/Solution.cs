namespace _1232.CheckForStraightLine;

internal class Solution
{
    public static bool CheckStraightLine(int[][] coordinates)
    {
        var first = coordinates[0];
        var second = coordinates[1];
        if (second[0] - first[0] == 0) return coordinates.All(xy => xy[0] == first[0]);
        var multiplier = 1;

        var numerator = second[1] - first[1];
        var denominator = second[0] - first[0];
        while ((multiplier * numerator) % denominator != 0)
        {
            multiplier++;
        }
        numerator *= multiplier;
        var m = numerator/denominator;
        var c = multiplier * first[1] - m * first[0];
        c *= multiplier;

        return coordinates.All(xy => xy[1] * multiplier == m * xy[0] + c);
    }
}