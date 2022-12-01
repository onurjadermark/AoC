namespace Solutions.Solutions._2020;

public class Day05
{
    public long Part1(string[] input)
    {
        return input.Select(GetId).Max();
    }

    public int Part2(string[] input)
    {
        var list = input.Select(GetId).OrderBy(x => x).ToList();
        for (var i = 0; i < list.Count; i++)
            if (i != 0 && list[i] == list[i - 1] + 2)
                return list[i] - 1;

        return -1;
    }

    private static int GetId(string line)
    {
        var (front, back, left, right) = (0, 127, 0, 7);

        for (var i = 0; i < 10; i++)
        {
            var curChar = line[i];
            switch (curChar)
            {
                case 'F':
                    back = (front + back) / 2;
                    break;
                case 'B':
                    front = (front + back) / 2 + 1;
                    break;
                case 'L':
                    right = (right + left) / 2;
                    break;
                case 'R':
                    left = (right + left) / 2 + 1;
                    break;
            }
        }

        var id = front * 8 + right;
        return id;
    }
}