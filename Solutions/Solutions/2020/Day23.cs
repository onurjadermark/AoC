namespace Solutions.Solutions._2020;

public class Day23
{
    public string Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public string Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static string Solve(string[] input, int part)
    {
        var linkedList = new LinkedList<int>();
        var nodes = new Dictionary<int, LinkedListNode<int>>();
        foreach (var cup in input.First().ToList().Select(x => int.Parse(x.ToString())).ToList())
            nodes[cup] = linkedList.AddLast(cup);

        if (part == 2)
            for (var i = linkedList.Max() + 1; i <= 1000000; i++)
                nodes[i] = linkedList.AddLast(i);

        var currentNode = new LinkedListNode<int>(linkedList.First());
        linkedList.RemoveFirst();
        linkedList.AddFirst(currentNode);
        nodes[linkedList.First()] = linkedList.First!;
        var moves = 0;
        var take = new List<LinkedListNode<int>>();
        while (true)
        {
            take.Clear();
            while (take.Count < 3)
            {
                var toTake = currentNode!.Next ?? linkedList.First;
                take.Add(toTake!);
                linkedList.Remove(toTake!);
            }

            var destination = currentNode!.Value - 1;
            if (destination < 1) destination = linkedList.Max();
            while (take.Any(x => x.Value == destination))
            {
                destination--;
                if (destination < 1) destination = linkedList.Max();
            }

            var destinationNode = nodes[destination];
            take.Reverse();
            foreach (var curTake in take) linkedList.AddAfter(destinationNode!, curTake);
            currentNode = currentNode.Next ?? linkedList.First;
            moves++;
            if ((part == 1 && moves == 100) || (part == 2 && moves == 10000000)) break;
        }

        if (part == 1)
        {
            var cups = linkedList.ToList();
            var oneIndex = cups.IndexOf(1);
            var result = linkedList.Skip(oneIndex + 1).Concat(cups.Take(oneIndex));
            return string.Join("", result);
        }
        else
        {
            var cups = linkedList.ToList();
            var index = cups.IndexOf(1);
            var result = (long) cups.ElementAt((index + 1) % cups.Count) *
                         cups.ElementAt((index + 2) % cups.Count);
            return result.ToString();
        }
    }
}