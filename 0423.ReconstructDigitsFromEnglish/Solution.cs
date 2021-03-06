using System.Text;

namespace _0423.ReconstructDigitsFromEnglish;

internal class Solution
{
    public static string OriginalDigits(string s)
    {
		var freqs = s.ToCharArray().GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
        var zero = Freq(freqs, 'z');
        var two = Freq(freqs, 'w');
        var four = Freq(freqs, 'u');
        var six = Freq(freqs, 'x');
        var eight = Freq(freqs, 'g');
        var three = Freq(freqs, 'h') - eight;
        var five = Freq(freqs, 'f') - four;
        var seven = Freq(freqs, 'v') - five;
        var one = Freq(freqs, 'o') - (zero + two + four);
        var nine = (Freq(freqs, 'n') - (one + seven)) / 2;
        var digs = new[] { zero, one, two, three, four, five, six, seven, eight, nine };

        var str = new StringBuilder();
        for (var i = 0; i < digs.Length; i++)
        for (var j = 0; j < digs[i]; j++)
            str.Append(i);

        return str.ToString();
    }

    private static int Freq(Dictionary<char, int> dict, char c) => dict.ContainsKey(c) ? dict[c] : 0;
}

