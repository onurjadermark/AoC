using System.Text;

namespace Solutions.Solutions._2022;

public class Day22
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return input.Length < 50 ? 0 : Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var height = input.Length - 2;
        var width = input.Take(height).Select(x => x.Length).Max();
        var map = input.Take(height).Select(x => x.PadRight(width, ' ')).ToArray();

        var path = input.Last();
        var pos = (X: input[0].IndexOf('.'), Y: 0);
        var direction = 0;
        var moves = new (int X, int Y)[] {(1, 0), (0, 1), (-1, 0), (0, -1)};
        var directions = new[] {'R', 'L'};

        for (var i = 0; i < path.Length; i++)
        {
            if (directions.Contains(path[i]))
            {
                direction = Turn(direction, path[i]);
                continue;
            }

            var stepCount = GetNumberOfSteps(path, i);
            i += stepCount.ToString().Length - 1;
            
            for (var j = 0; j < stepCount; j++)
            {
                var prev = (pos, direction);
                pos = (pos.X + moves[direction].X, pos.Y + moves[direction].Y);
                if (part == 1)
                {
                    (pos, direction) = Normalize(pos, width, height, direction, part);
                    while (map[pos.Y][pos.X] == ' ')
                    {
                        pos = (pos.X + moves[direction].X, pos.Y + moves[direction].Y);
                        (pos, direction) = Normalize(pos, width, height, direction, part);
                    }
                }
                else
                {
                    if (pos.X == -1 || pos.Y == -1 || pos.X == width || pos.Y == height || map[pos.Y][pos.X] == ' ')
                    {
                        (pos, direction) = NormalizeInCube(pos, direction);
                    }
                }

                if (map[pos.Y][pos.X] == '#')
                {
                    (pos, direction) = prev;
                    break;
                }
            }
        }

        return (pos.Y + 1) * 1000 + (pos.X + 1) * 4 + direction;
    }

    private static int GetNumberOfSteps(string path, int i)
    {
        var sb = new StringBuilder();
        while (i < path.Length && IsDigit(path[i]))
        {
            sb.Append(path[i]);
            i++;
        }
        return int.Parse(sb.ToString());
    }

    private static int Turn(int direction, char turn)
    {
        direction = turn switch
        {
            'R' => (direction + 1),
            'L' => (direction - 1),
            _ => direction
        };
        if (direction < 0) direction = 3;
        if (direction >= 4) direction = 0;
        return direction;
    }

    private static ((int X, int Y), int Direction) Normalize((int X, int Y) pos, int width, int height, int direction, int part)
    {
        if (pos.X < 0) pos = (width - 1, pos.Y);
        if (pos.Y < 0) pos = (pos.X, height - 1);
        if (pos.X >= width) pos = (0, pos.Y);
        if (pos.Y >= height) pos = (pos.X, 0);
        return (pos, direction);
    }

    private static ((int X, int Y), int Direction) NormalizeInCube((int X, int Y) pos, int direction)
    {
        return pos switch
        {
            //1-6
            {X: >= 100 and < 150, Y: -1} when direction == 3 => ((pos.X - 100, 199), 3), //U
            {X: >= 0 and < 50, Y: 200} when direction == 1 => ((pos.X + 100, 0), 1), //D
            //1-4
            {X: 150, Y: >= 0 and < 50} when direction == 0 => ((99, 149 - pos.Y), 2), //R
            {X: 100, Y: >= 100 and < 150} when direction == 0 => ((149, 149 - pos.Y), 2), //R
            //1-3
            {X: >= 100 and < 150, Y: 50} when direction == 1 => ((99, pos.X - 50), 2), //D
            {X: 100, Y: >= 50 and < 100} when direction == 0 => ((pos.Y + 50, 49), 3), //R
            //2-6
            {X: >= 50 and < 100, Y: -1} when direction == 3 => ((0, pos.X + 100), 0), //U
            {X: -1, Y: >= 150 and < 200} when direction == 2 => ((pos.Y - 100, 0), 1), //L
            //2-5
            {X: 49, Y: >= 0 and < 50} when direction == 2 => ((0, 149 - pos.Y), 0), //L
            {X: -1, Y: >= 100 and < 150} when direction == 2 => ((50, 149 - pos.Y), 0), //L
            //3-5
            {X: 49, Y: >= 50 and < 100} when direction == 2 => ((pos.Y - 50, 100), 1), //L
            {X: >= 0 and < 50, Y: 99} when direction == 3 => ((50, 50 + pos.X), 0), //U
            //4-6
            {X: >= 50 and < 100, Y: 150} when direction == 1 => ((49, 100 + pos.X), 2), //D
            {X: 50, Y: >= 150 and < 200} when direction == 0 => ((pos.Y - 100, 149), 3), //R
            _ => throw new Exception()
        };
    }

    private static bool IsDigit(char cur)
    {
        return cur is >= '0' and <= '9';
    }
}