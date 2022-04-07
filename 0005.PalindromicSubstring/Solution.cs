using System.Globalization;

namespace _0005.PalindromicSubstring;

internal class Solution
{
    public static string LongestPalindrome(string s)
    {
        var j = s.Length - 1;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != s[j])
            {
                if (s[i] == s[j - 1]) j--;
                else if (s[i+1] == s[j]) i++;
                else if (i % 2 == 0) i++;
                else j--;
            }

            var start = i;
            var end = j;
            while (i < j && s[i++] == s[j--]) ;
            if(i >= j)
                return s.Substring(start, end - start);
        }

        return "";
    }
}