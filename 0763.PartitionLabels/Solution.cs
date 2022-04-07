namespace _0763.PartitionLabels;

internal class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        var n = s.Length;
        var last = new int[26];

        // keep track of last index seen
        for (var i = 0; i < n; i++)
            last[s[i] - 'a'] = i;

        var result = new List<int>();
        var startIdx = 0;
        var currLast = -1; // keep track of the current maximum last index seen
        for (var i = 0; i < n; i++)
        {
            var c = s[i] - 'a';
            currLast = Math.Max(currLast, last[c]);

            if (i != currLast) continue;

            var length = i + 1;
            result.Add(length - startIdx);
            startIdx = length;
        }

        return result;
    }
}
