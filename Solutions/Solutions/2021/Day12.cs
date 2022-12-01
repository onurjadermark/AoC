namespace Solutions.Solutions._2021;

public class Day12
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var currentPath = new List<string> {"start"};
        var graph = MakeGraph(input);
        var finishedPaths = new List<List<string>>();
        var usedLowercasePaths = new HashSet<string>();
        var allowTwoSameLowercase = part == 2;
        Traverse(part, currentPath, graph, finishedPaths, usedLowercasePaths, allowTwoSameLowercase);
        return finishedPaths.Count;
    }

    private static Dictionary<string, List<string>> MakeGraph(string[] input)
    {
        var graph = new Dictionary<string, List<string>>();
        foreach (var line in input)
        {
            var split = line.Split("-");
            if (!graph.ContainsKey(split[0])) graph[split[0]] = new List<string>();

            if (!graph.ContainsKey(split[1])) graph[split[1]] = new List<string>();

            graph[split[0]].Add(split[1]);
            graph[split[1]].Add(split[0]);
        }

        return graph;
    }

    private void Traverse(int part, List<string> currentPath, Dictionary<string, List<string>> graph,
        List<List<string>> finishedPaths,
        HashSet<string> usedLowercasePaths, bool allowTwoSameLowercase)
    {
        var toTraverse = graph[currentPath.Last()].Where(x => x != "start").ToList();

        toTraverse = part == 1
            ? toTraverse.Where(x => !usedLowercasePaths.Contains(x)).ToList()
            : toTraverse.Where(x => allowTwoSameLowercase || !usedLowercasePaths.Contains(x)).ToList();

        foreach (var path in toTraverse)
        {
            currentPath.Add(path);
            if (currentPath.Last() == "end")
            {
                finishedPaths.Add(currentPath);
                continue;
            }

            var prevAllowTwoSameLowercase = allowTwoSameLowercase;
            var seen = usedLowercasePaths.Contains(path);
            if (IsLower(path))
            {
                usedLowercasePaths.Add(path);
                if (seen) allowTwoSameLowercase = false;
            }

            Traverse(part, currentPath, graph, finishedPaths, usedLowercasePaths, allowTwoSameLowercase);

            allowTwoSameLowercase = prevAllowTwoSameLowercase;
            currentPath.RemoveAt(currentPath.Count - 1);
            if (!seen) usedLowercasePaths.Remove(path);
        }
    }

    private static bool IsLower(string str)
    {
        return str[0] >= 'a' && str[0] <= 'z';
    }
}