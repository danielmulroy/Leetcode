namespace _0072.EditDistance;

public class Solution
{
    private static string w1;
    private static string w2;
    private static int[,] distance;

    public static int MinDistance(string word1, string word2)
    {
        if (word1.Length == 0) return word2.Length;
        if (word2.Length == 0) return word1.Length;
        
        w1 = word1;
        w2 = word2;
        distance = new int[w1.Length + 1,w2.Length + 1];
        for (var i = 1; i <= w1.Length; i++)
        {
            distance[i, 0] = i;
        }
        for (var i = 1; i <= w2.Length; i++)
        {
            distance[0, i] = i;
        }

        return CalculateAtPoint(word1.Length, word2.Length);
    }

    private static int CalculateAtPoint(int i, int j)
    {
        if (i == 0 && j == 0) return 0;

        distance[i - 1, j] = distance[i - 1, j] == 0 ? CalculateAtPoint(i - 1, j) : distance[i - 1, j];
        distance[i, j - 1] = distance[i, j - 1] == 0 ? CalculateAtPoint(i, j - 1) : distance[i, j - 1];
        distance[i - 1, j - 1] = distance[i - 1, j - 1] == 0 ? CalculateAtPoint(i - 1, j - 1) : distance[i - 1, j - 1];
        
        return 1 + Math.Min(distance[i, j - 1], Math.Min(distance[i - 1, j], distance[i - 1, j - 1] - Convert.ToInt32(w1[i - 1] == w2[j - 1])));
    }
}