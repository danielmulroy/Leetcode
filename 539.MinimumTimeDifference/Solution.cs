namespace _539.MinimumTimeDifference;

public class Solution
{
    public static int FindMinDifferenceBrute(IList<string> timePoints)
    {
        var minDiff = TimeSpan.FromHours(13).TotalMinutes;
        for (var i = 0; i < timePoints.Count; i++)
        {
            var point1 = timePoints[i];
            for (var j = 0; j < timePoints.Count && i != j; j++)
            {
                var point2 = timePoints[j];
                var diff = Math.Abs(DateTime.Parse(point1).Subtract(DateTime.Parse(point2)).TotalMinutes);
                var invDiff = Math.Abs(diff - 60 * 24);
                minDiff = Math.Min(minDiff, Math.Min(diff, invDiff));
                if (minDiff < 0.5) break;
            }

            if (minDiff < 0.5) break;
        }

        return Convert.ToInt32(minDiff);
    }
    public static int FindMinDifference(IList<string> timePoints)
    {
        const int HOURS_IN_DAY = 24;
        const int HOURS_IN_HALF_DAY = 12;
        const int MINUTES_IN_HOUR = 60;


        //Inserting to a SortedSet<T> is a O(log n) operation
        SortedSet<int> ss = new();

        foreach (var s in timePoints)
        {
            var temp = s.Split(':');

            if (!ss.Add(int.Parse(temp[0]) * MINUTES_IN_HOUR + int.Parse(temp[1])))
                return 0;
        }

        var v = ss.ToArray();

        var min = int.MaxValue;

        for (var i = 1; i<v.Length; ++i)
            min = Math.Min(min, v[i] - v[i - 1]);

        var last = v[^1] - v[0];

        if (last > HOURS_IN_HALF_DAY * MINUTES_IN_HOUR)
            last = Math.Min(last, MINUTES_IN_HOUR * HOURS_IN_DAY - v[^1] + v[0]);

        return Math.Min(min, last);
    }

}