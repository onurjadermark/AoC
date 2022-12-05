namespace Solutions.Solutions._2022;

public class Day05
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
        var stacks = new List<Stack<char>>();
        var tempStacks = new List<Stack<char>>();
        for (var i = 0; i < 9; i++)
        {
            stacks.Add(new Stack<char>());
            tempStacks.Add(new Stack<char>());
        }

        foreach (var line in input)
        {
            if (line.StartsWith(" 1 "))
            {
                break;
            }

            for (var i = 0; i < line.Length; i++)
            {
                if (i % 4 == 1 && line[i] != ' ')
                {
                    tempStacks[i / 4].Push(line[i]);
                }
            }
        }

        for (var i = 0; i < 9; i++)
        {
            while (tempStacks[i].Any())
            {
                stacks[i].Push(tempStacks[i].Pop());
            }
        }

        foreach (var line in input.Where(x => x.StartsWith("move")))
        {
            var count = int.Parse(line.Substring(5, 2).Trim());
            var source = int.Parse(line.Substring(12, 2).Trim()) - 1;
            var destination = int.Parse(line.Substring(17).Trim()) - 1;

            if (part == 1)
            {
                for (var i = 0; i < count; i++)
                {
                    stacks[destination].Push(stacks[source].Pop());
                }
            }
            else
            {
                var temp = new Stack<char>();
                for (var i = 0; i < count; i++)
                {
                    temp.Push(stacks[source].Pop());
                }

                for (var i = 0; i < count; i++)
                {
                    stacks[destination].Push(temp.Pop());
                }
            }
        }

        var result = "";
        for (var i = 0; i < 9; i++)
        {
            if (stacks[i].Any())
            {
                result += stacks[i].Peek();
            }
        }

        return result;
    }
}