using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1405.LongestHappyString;

internal static class Logic
{
    public static string LongestDiverseString(int a, int b, int c)
    {
        var set = new SortedSet<(int, char)>();
        set.Add((a, 'a'));
        set.Add((b, 'b'));
        set.Add((c, 'c'));

        var sb = new StringBuilder();
        var lastChar = 'd';

        while ((set.Max.Item1 > 0 && lastChar != set.Max.Item2) || (set.ElementAt(1).Item1 > 0))
        {
            var obj = set.Max;
            var rem = 1;
            if (lastChar == obj.Item2)
            {
                obj = set.ElementAt(1);
                sb.Append(obj.Item2);
            }
            else
            {
                if (obj.Item1 > 1)
                {
                    sb.Append(obj.Item2).Append(obj.Item2);
                    rem = 2;
                }
                else sb.Append(obj.Item2);
            }
            set.Remove(obj);
            set.Add((obj.Item1 - rem, obj.Item2));
            lastChar = obj.Item2;
        }

        return sb.ToString();
    }
}