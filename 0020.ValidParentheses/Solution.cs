namespace _0020.ValidParentheses;

internal class Solution
{
    public static bool IsValid(string s)
    {
        if (s.Length == 1) return false;
        if (s.Length % 2 == 1) return false;
        if (s.First() is ')' or '}' or ']') return false;
        var map = new Dictionary<char, char>();
        map.Add(')', '(');
        map.Add(']', '[');
        map.Add('}', '{');
        var stack = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == '(' || c == '{' || c == '[') stack.Push(c);
            else if (stack.Any())
            {
                if (stack.Pop() != map[c]) return false;
            }
            else return false;
        }
        return !stack.Any();
    }
}