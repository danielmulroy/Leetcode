namespace _0004.MedianOfSortedArrays;

internal class Solution
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var l = nums1.ToList();
        var index = 0;
        for (var i = 0; i < nums2.Length; i++)
        {
            var insert = nums2[i];
            while (index < l.Count && l[index] < insert)
            {
                index++;
            }
            l.Insert(index, insert);
            index++;
        }

        if (l.Count % 2 != 0) 
            return l[l.Count / 2];

        var a = l[(l.Count + 1) / 2] + l[(l.Count - 1) / 2];
        return Convert.ToDouble(a) / 2;
    }
}