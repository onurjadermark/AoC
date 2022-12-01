namespace Solutions.Solutions._2018;

public class Day05
{
    public int Part1(string input)
    {
        var polymer = input.ToList();
        for (var i = 0; i < polymer.Count - 1; i++)
        {
            if (i == -1) i++;
            var cur = polymer[i];
            var next = polymer[i + 1];
            if (Math.Abs(cur - next) == 32)
            {
                polymer.RemoveRange(i, 2);
                i -= 2;
            }
        }

        return polymer.Count;
    }

    public int Part2(string input)
    {
        var minimumLength = int.MaxValue;
        for (var i = 0; i < 32; i++)
        {
            var polymer = new Stack<char>(input.Where(x => x != 'a' + i && x != 'a' + i - 32).ToList());
            var result = new Stack<char>();
            while (polymer.Count > 1)
            {
                var cur = polymer.Pop();
                var next = polymer.Peek();
                if (Math.Abs(cur - next) == 32)
                {
                    polymer.Pop();
                    if (result.Any()) polymer.Push(result.Pop());
                }
                else
                {
                    result.Push(cur);
                }
            }

            result.Push(polymer.Pop());

            if (result.Count < minimumLength) minimumLength = result.Count;
        }

        return minimumLength;
    }
}