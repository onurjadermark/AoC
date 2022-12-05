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
        for (int i = 0; i < 9; i++)
        {
            stacks.Add(new Stack<char>());
            tempStacks.Add(new Stack<char>());
        }

        foreach (var line in input)
        {
            while (!string.IsNullOrWhiteSpace(line))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (i % 4 == 1 && line[i] != ' ')
                    {
                        tempStacks[i / 4].Push(line[i]);
                    }
                }

                break;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (tempStacks[i].Any())
                tempStacks[i].Pop();
        }

        for (int i = 0; i < 9; i++)
        {
            while (tempStacks[i].Any())
            {
                stacks[i].Push(tempStacks[i].Pop());
            }
        }

        foreach (var line in input.SkipWhile(x => !string.IsNullOrWhiteSpace(x)))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var num1 = int.Parse(line.Substring(4, 3).Trim());
            var num2 = int.Parse(line.Substring(12, 2).Trim()) - 1;
            var num3 = int.Parse(line.Substring(17).Trim()) - 1;

            if (part == 1)
            {
                for (int i = 0; i < num1; i++)
                {
                    stacks[num3].Push(stacks[num2].Pop());
                }
            }
            else
            {
                var temp = new Stack<char>();
                for (int i = 0; i < num1; i++)
                {
                    temp.Push(stacks[num2].Pop());
                }

                for (int i = 0; i < num1; i++)
                {
                    stacks[num3].Push(temp.Pop());
                }
            }
        }

        var result = "";
        for (int i = 0; i < 9; i++)
        {
            if (stacks[i].Any())
            {
                result += stacks[i].Peek();
            }
        }

        return result;
    }
}