namespace _1319.NoOfOperationsToConnectNetwork;

public class Solution
{
    public static int MakeConnected(int n, int[][] connections)
    {
        if (n > connections.Length + 1)
            return -1;

        var dict = new Dictionary<int, List<int>>();
        for (var i = 0; i < n; i++)
        {
            dict.Add(i, new List<int>());
        }
        foreach (var con in connections)
        {
            dict[con[0]].Add(con[1]);
            dict[con[1]].Add(con[0]);
        }

        var visited = new bool[n];
        var count = -1;
        for (var i = 0; i < n; i++)
        {
            if (visited[i]) continue;

            DepthFirstSearch(i, dict, ref visited);
            count++;
        }

        return count;
    }

    private static void DepthFirstSearch(int currentKey, Dictionary<int, List<int>> dict, ref bool[] visited)
    {
        visited[currentKey] = true;

        var connections = dict.ContainsKey(currentKey) ? dict[currentKey] : new List<int>();

        foreach (var connection in connections)
        {
            if (visited[connection]) continue;

            DepthFirstSearch(connection, dict, ref visited);
        }
    }
}