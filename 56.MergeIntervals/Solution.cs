
namespace _56.MergeIntervals;
public static class Solution
{
    /// <summary>
    /// Only works if intervals are ordered...ie. [[1,3],[2,6],[8,10],[15,18]]
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    //public static int[][] Merge(int[][] intervals)
    //{
    //    var ret = new List<int[]>();
    //    var carrying = false;
    //    int[] window = new int[2];

    //    for (var i = 0; i < intervals.Length; i++)
    //    {
    //        var current = intervals[i];

    //        if (!carrying)
    //        {
    //            window = new int[2];
    //            window[0] = current[0];
    //        }

    //        if (i + 1 != intervals.Length && current[1] >= intervals[i + 1][0])
    //        {
    //            window[0] = Math.Min(window[0], intervals[i + 1][0]);
    //            carrying = true;
    //        }
    //        else
    //        {
    //            window[1] = current[1];
    //            carrying = false;
    //        }

    //        if (!carrying) ret.Add(window);
    //    }

    //    return ret.ToArray();
    //}

    public static int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var ret = new List<int[]>();
        var adding = true;
        var window = new int[2];

        for (var i = 0; i < intervals.Length; i++)
        {
            var current = intervals[i];

            if (adding)
            {
                window = new int[2];
                window[0] = current[0];
            }

            window[1] = Math.Max(window[1], current[1]);

            adding = i + 1 == intervals.Length || window[1] < intervals[i + 1][0];

            if (adding) ret.Add(window);
        }

        return ret.ToArray();
    }

    //public record Window
    //{
    //    public int Upper;
    //    public int Lower;

    //    public int[] ToArray()
    //    {
    //        return new[] { Lower, Upper };
    //    }
    //}

    //public static int[][] Merge(int[][] intervals)
    //{
    //    var windows = new List<Window>();
    //    for (var i = 0; i < intervals.Length; i++)
    //    {
    //        var current = intervals[i];
    //        var lower = current[0];
    //        var upper = current[1];

    //        //var indexes = windows.Select((w, i) => new {i, w})
    //        //    .Where(t => t.w.Lower <= lower && t.w.Upper >= lower || t.w.Lower <= upper && t.w.Upper >= upper || t.w.Lower >= lower && t.w.Upper <= upper)
    //        //    .Select(t => (t.i, t.w));
    //        var matches = windows.Where(w =>
    //            w.Lower <= lower && w.Upper >= lower || w.Lower <= upper && w.Upper >= upper ||
    //            w.Lower >= lower && w.Upper <= upper).ToArray();
    //        if (matches.Any())
    //        {
    //            var max = upper;
    //            var min = lower;
    //            foreach (var window in matches)
    //            {
    //                max = Math.Max(max, window.Upper);
    //                min = Math.Min(min, window.Lower);
    //                windows.Remove(window);
    //            }

    //            windows.Add(new Window { Lower = min, Upper = max });
    //        }
    //        else
    //        {
    //            windows.Add(new Window { Lower = lower, Upper = upper });
    //        }
    //    }

    //    return windows.Select(w => w.ToArray()).ToArray();
    //}
}