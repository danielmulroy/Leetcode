using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _151.ReverseWordsInString;

public static class Logic
{
    public static string ReverseWords(string s)
    {
        var stack = new Stack<string>();
        foreach (var str in s.Split(' ', StringSplitOptions.TrimEntries))
        {
            stack.Push(str);
        }

        var sb = new StringBuilder();
        while (stack.TryPop(out var popped))
        {
            if (!string.IsNullOrWhiteSpace(popped)) sb.Append(popped + " ");
        }
        return sb.ToString().Trim();
    }
}