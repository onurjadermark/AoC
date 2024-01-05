namespace Solutions.Solutions._2023
{
    public class Day25
    {
        public int Part1(string[] input)
        {
            var random = new Random();

            while (true)
            {
                var graph = ParseGraph(input);
                var sizes = graph.Keys.ToDictionary(x => x, _ => 1);

                while (graph.Count > 2)
                {
                    var (firstNode, secondNode) = GetRandomEdge(graph, random);
                    var newNode = random.Next(int.MaxValue).ToString();
                    MergeNodes(graph, newNode, firstNode, secondNode);
                    UpdateNodes(graph, newNode, firstNode);
                    UpdateNodes(graph, newNode, secondNode);
                    sizes[newNode] = sizes[firstNode] + sizes[secondNode];
                    graph.Remove(firstNode);
                    graph.Remove(secondNode);
                }

                if (graph[graph.Keys.ElementAt(0)].Count == 3)
                {
                    return sizes[graph.Keys.ElementAt(0)] * sizes[graph.Keys.ElementAt(1)];
                }
            }
        }

        private static Dictionary<string, List<string>> ParseGraph(IEnumerable<string> input)
        {
            var graph = new Dictionary<string, List<string>>();

            foreach (var line in input)
            {
                var parts = line.Split(":", StringSplitOptions.TrimEntries);
                var (leftNode, connectedNodes) = (parts[0], parts[1].Split(' ', StringSplitOptions.TrimEntries));

                graph.TryAdd(leftNode, []);

                foreach (var rightNode in connectedNodes)
                {
                    graph.TryAdd(rightNode, []);
                    graph[leftNode].Add(rightNode);
                    graph[rightNode].Add(leftNode);
                }
            }

            return graph;
        }

        private static (string, string) GetRandomEdge(Dictionary<string, List<string>> graph, Random random)
        {
            var firstNode = graph.Keys.ElementAt(random.Next(graph.Count));
            var secondNode = graph[firstNode][random.Next(graph[firstNode].Count)];
            return (firstNode, secondNode);
        }

        private static void MergeNodes(Dictionary<string, List<string>> graph, string newNode, string nodeA, string nodeB)
        {
            graph[newNode] = graph[nodeA].Where(x => x != nodeB).Concat(graph[nodeB].Where(x => x != nodeA)).ToList();
        }

        private static void UpdateNodes(Dictionary<string, List<string>> graph, string newNode, string oldNode)
        {
            foreach (var node in graph[oldNode].Where(node => graph[node].Contains(oldNode)))
            {
                graph[node].Remove(oldNode);
                graph[node].Add(newNode);
            }
        }
    }
}
