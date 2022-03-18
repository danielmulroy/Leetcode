using System.Data;

namespace _811.SubdomainVisitCount;

public class Solution
{
    private static Dictionary<string, int> map = new();
    public static IList<string> SubdomainVisits(string[] cpdomains)
    {
        foreach (var domain in cpdomains)
        {
            var split = domain.Split(' ');
            GetVisitCount(split[1], Convert.ToInt32(split[0]));
        }

        return map.Select(kvp => $"{kvp.Value} {kvp.Key}").ToList();
    }

    public static void GetVisitCount(string domain, int visits)
    {
        if (map.ContainsKey(domain))
            map[domain] += visits;
        else
            map.Add(domain, visits);

        if (domain.Contains('.'))
            GetVisitCount(domain[(domain.IndexOf('.') + 1)..], visits);
    }

}