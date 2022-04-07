using System.Text;

namespace _0068.TextJustification;

internal class Solution
{
    public static IList<string> FullJustify(string[] words, int maxWidth)
    {
        var wordList = new List<string>();
        for (var i = 0; i < words.Length; i++)
        {
            var sb = new StringBuilder();
            var charCount = 0;
            var word = words[i];
            var line = new List<StringBuilder> { new(word) };
            charCount += word.Length;

            while (i < words.Length - 1 && charCount + 1 + words[i + 1].Length <= maxWidth)
            {
                i++;
                line.Add(new StringBuilder(" "));
                line.Add(new StringBuilder(words[i]));
                charCount += 1 + words[i].Length;
            }

            var missing = maxWidth - charCount;
            var j = 0;
            if (i == words.Length - 1)
            {
                while (missing > 0)
                {
                    line.Last().Append(' ');
                    missing--;
                }
            }
            else
            {
                int counter;
                if (line.Count == 1)
                {
                    line.Add(new StringBuilder(""));
                    counter = 1;
                }
                else
                {
                    counter = (line.Count - 1) / 2;
                }

                while (missing > 0)
                {
                    var index = 2 * (j % counter) + 1;
                    line[index].Append(' ');
                    missing--;
                    j++;
                }
            }
            
            foreach (var part in line)
            {
                sb.Append(part);
            }
            wordList.Add(sb.ToString());
        }
        return wordList;
    }
}