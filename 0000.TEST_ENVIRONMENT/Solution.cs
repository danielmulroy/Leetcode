namespace _0000.TEST_ENVIRONMENT;

internal static class Solution
{
    public static int HeightChecker(int[] heights)
    {
        var start = new int[heights.Length];
        Array.Copy(heights, start, heights.Length);
        Array.Sort(heights);
        var count = 0;

        for (var i = 0; i < heights.Length; i++)
        {
            var a = start[i];
            var b = heights[i];

            if (a != b) count++;
        }
        Console.WriteLine(heights[2]);
        Console.WriteLine(start[2]);

        return count;
    }

    public static bool IsLongPressedName(string name, string typed) // "saeed", "ssaaedd", out FALSE
    {
        if (name.Length > typed.Length) return false;

        var indexInTyped = 0;
        for (var i = 0; i < name.Length; i++)
        {
            var c = name[i];
            if (indexInTyped < typed.Length && c != typed[indexInTyped]) return false;
            if (i == name.Length - 1 && indexInTyped == typed.Length && c != typed[indexInTyped - 1]) return false;
            while (indexInTyped < typed.Length && typed[indexInTyped] == c)
            {
                indexInTyped++;
            }

            if (i < name.Length - 1 && c == name[i + 1] && c == typed[indexInTyped + 1]) i++;
        }

        return indexInTyped == typed.Length;
    }
}