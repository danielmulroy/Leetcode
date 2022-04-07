using System.ComponentModel;
using System.Text;
using System.Transactions;

namespace _1909.CanOneBeRemovedToBeIncreasing;

public class Solution
{
    //public static bool CanBeIncreasing(int[] nums)
    //{
    //    bool ascending;
    //    for (var i = 0; i < nums.Length; i++)
    //    {
    //        var val = nums[i];
    //        var prev = nums[i - 1];
    //        ascending = val > prev;
    //        if (!ascending && i > 1) prev = nums[i - 2];
    //        else prev = val;
    //        if (ascending)
    //        {
    //            continue;
    //        }
    //        hitProblemo++;
    //    }
    //    return hitProblemo < 2;
    //}

    public static string LargestTimeFromDigits(int[] arr)
    {
        var highestA = (-1, -1); // (value, index)
        var highestB = (-1, -1); // (value, index)
        var highestC = (-1, -1); // (value, index)
        //var theRest = new TopTwo();
        var final = -1;

        for (var i = 0; i < arr.Length; i++)
        {
            var cur = arr[i];
            if (cur < 3 && cur > highestA.Item1)
                highestA = (cur, i);
        }
        if (highestA.Item1 == -1) return "";

        var max = highestA.Item1 == 2 ? 4 : 10;
        for (var i = 0; i < arr.Length; i++)
        {
            var cur = arr[i];
            if (i != highestA.Item2 && cur < max && cur > highestB.Item1)
                highestB = (cur, i);
        }
        if (highestB.Item1 == -1) return "";

        for (var i = 0; i < arr.Length; i++)
        {
            var cur = arr[i];
            if (i != highestA.Item2 && i != highestB.Item2 && cur < 6 && cur > highestC.Item1)
                highestC = (cur, i);
        }
        if (highestC.Item1 == -1) return "";

        for (var i = 0; i < arr.Length; i++)
        {
            if (highestA.Item2 == i || highestB.Item2 == i || highestC.Item2 == i) continue;
            final = Math.Max(final, arr[i]);
        }

        if (final == -1) return "";

        var sb = new StringBuilder();
        sb.Append(highestA.Item1);
        sb.Append(highestB.Item1);
        sb.Append(':');
        sb.Append(highestC.Item1);
        sb.Append(final);
        return sb.ToString();
    }
}

public class TopTwo
{
    private int[] values = new [] {-1, -1};
    private int count = 0;

    public void Add(int i)
    {
        count++;
        if (i > values[1])
        {
            values[0] = values[1];
            values[1] = i;
        }
        else if (i > values[0])
        {
            values[0] = i;
        }
    }

    public int Biggest()
    {
        return values[1];
    }
    public int SecondBiggest()
    {
        return values[0];
    }

    public bool Full()
    {
        return count > 1;
    }
}
