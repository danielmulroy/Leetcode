using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LongestSubstringWithoutRepeats
{
    internal static class Logic
    {
        public static int LengthOfLongestSubstring(string s)
        {
            var arr = s.ToCharArray();
            var longest = 0;
            var visited = new List<char>();
            foreach (var c in arr)
            {
                if (visited.Contains(c))
                {
                    visited = visited.Skip(visited.IndexOf(c) + 1).ToList();
                }
                visited.Add(c);
                longest = Math.Max(longest, visited.Count);
            }

            return Math.Max(longest, visited.Count);
        }
    }
}
