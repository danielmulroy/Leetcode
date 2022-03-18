namespace _1909.CanOneBeRemovedToBeIncreasing;

public class Solution
{
    public static bool CanBeIncreasing(int[] nums)
    {
        bool ascending;
        for (var i = 0; i < nums.Length; i++)
        {
            var val = nums[i];
            var prev = nums[i - 1];
            ascending = val > prev;
            if (!ascending && i > 1) prev = nums[i - 2];
            else prev = val;
            if (ascending)
            {
                continue;
            }
            hitProblemo++;
        }
        return hitProblemo < 2;
    }
}
