using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TwoSum;

internal static class Logic
{
    public static int[] TwoSumBrute(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            for (var j = 0; j < nums.Length; j++)
            {
                var num2 = nums[j];
                if (num + num2 == target)
                    return new[] { i, j };
            }
        }

        return Array.Empty<int>();
    }

    public static int[] TwoSumTwoPass(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (!map.ContainsKey(num))
                map.Add(num, i);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var aim = target - num;
            if (map.ContainsKey(aim))
                return new[] { map[aim], i };
        }

        return Array.Empty<int>();
    }

    public static int[] TwoSumOnePass(int[] nums, int target)
    {
        var result = new int[2];
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var aim = target - num;
            if (map.TryGetValue(aim, out result[0]))
            {
                result[1] = i;
                return result;
            }
            if (!map.ContainsKey(num))
                map.Add(num, i);
        }

        return Array.Empty<int>();
    }
}