namespace _0015.ThreeSum;

internal class Solution
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();

        Array.Sort(nums);

        for (var i = 0; i < nums.Length - 2 && nums[i] <= 0; i++)
        {
            if (i != 0 && nums[i - 1] == nums[i]) continue;

            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k && nums[i] >= -nums[k] * 2)
            {
                switch (nums[i] + nums[j] + nums[k])
                {
                    case < 0:
                        while (nums[j++] == nums[j] && j < k) ;
                        break;
                    case > 0:
                        while (nums[k--] == nums[k] && j < k) ;
                        break;
                    default:
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        while (nums[j++] == nums[j] && j < k) ;
                        while (nums[k--] == nums[k] && j < k) ;
                        break;
                }
            }
        }

        return result;
    }
}