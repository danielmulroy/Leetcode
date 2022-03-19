namespace _0718.MaxLengthOfRepeatedSubarray;

internal class Solution
{
    public static int FindLengthTooLong(int[] nums1, int[] nums2)
    {
        var longest = 0;
        for (var i = 0; i < nums1.Length; i++)
        {
            var current = nums1[i];
            var nums2index = 0;
            var attempts = 0;
            while (nums2index != -1)
            {
                nums2index = Array.IndexOf(nums2, current, attempts);
                if (nums2index == -1) continue;
                attempts++;
                nums2index++;
                var nums1index = i + 1;
                var length = 1;
                while (nums1index != nums1.Length && nums2index != nums2.Length)
                {
                    if (nums1[nums1index] == nums2[nums2index]) length++;
                    else break;
                    nums1index++;
                    nums2index++;
                }
                longest = Math.Max(longest, length); 
            }
        }

        return longest;
    }

    public static int FindLength(int[] nums1, int[] nums2)
    {
        var ans = 0;
        var lengths = new int[nums1.Length + 1,nums2.Length + 1];
        for (var i = nums1.Length - 1; i >= 0; --i)
        {
            for (var j = nums2.Length - 1; j >= 0; --j)
            {
                if (nums1[i] != nums2[j]) continue;

                lengths[i,j] = lengths[i + 1,j + 1] + 1;
                ans = Math.Max(ans, lengths[i,j]);
            }
        }
        return ans;
    }
}