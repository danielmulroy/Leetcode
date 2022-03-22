namespace _0136.SingleNumber;

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        var hits = new HashSet<int>();
        foreach (var num in nums)
        {
            if (hits.Contains(num)) hits.Remove(num);
            else hits.Add(num);
        }

        return hits.First();
    }

    public int SingleNumberLinq(int[] nums)
    {
        return nums.Aggregate(0, (current, num) => current ^ num);
    }
}