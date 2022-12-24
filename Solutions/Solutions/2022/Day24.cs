namespace Solutions.Solutions._2022;

public class Day24
{
    [Flags]
    private enum Directions
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8
    }
    
    private class State
    {
        public int Minute { get; set; }
        public (int X, int Y) Position { get; set; }
        public bool HasBeenToFinish { get; set; }
        public bool HasSnacks { get; set; }
    }

    private readonly (int X, int Y)[] _moves = {(0, 1), (1, 0), (0, -1), (-1, 0)};
    
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private int Solve(string[] input, int part)
    {
        var width = input[0].Length - 2;
        var height = input.Length - 2;
        var loopSize = width * height / GCD(width, height);
        var map = new int[loopSize][][];
        for (int i = 0; i < loopSize; i++)
        {
            map[i] = new int[height][];
            for (int j = 0; j < height; j++)
            {
                map[i][j] = new int[width];
                for (int k = 0; k < width; k++)
                {
                    if (i == 0)
                    {
                        map[i][j][k] = ParseInput(input[j + 1][k + 1]);
                    }
                    else
                    {
                        map[i][j][k] = (int) (((Directions) map[i - 1][(j + 1) >= height ? 0 : j + 1][k] & Directions.Up) |
                                              ((Directions) map[i - 1][j][(k - 1) < 0 ? width - 1 : k - 1] & Directions.Right) |
                                              ((Directions) map[i - 1][j - 1 < 0 ? height - 1 : j - 1][k] & Directions.Down) |
                                              ((Directions) map[i - 1][j][k + 1 >= width ? 0 : k + 1] & Directions.Left));
                    }
                }
            }
        }

        var queue = new PriorityQueue<State, int>();
        queue.Enqueue(new State() {Position = (0, -1), Minute = 0}, 0);
        var best = int.MaxValue;
        var visited = new HashSet<(int X, int Y, int Minute, bool HasBeenToFinish, bool HasSnacks)>();
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            if (cur.Minute > 1000) continue;
            if (cur.Position == (width - 1, height - 1) && (part == 1 || cur.HasSnacks) && cur.Minute < best)
            {
                best = cur.Minute;
                continue;
            }
            
            if (cur.Position == (width - 1, height - 1))
            {
                if (!visited.Contains((cur.Position.X, cur.Position.Y, cur.Minute + 3, true, false)))
                {
                    visited.Add((cur.Position.X, cur.Position.Y, cur.Minute + 3, true, false));
                    queue.Enqueue(new State()
                    {
                        Position = (cur.Position.X, cur.Position.Y),
                        Minute = cur.Minute + 3,
                        HasSnacks = false,
                        HasBeenToFinish = true
                    }, -cur.Position.X - cur.Position.Y + cur.Minute + 3);
                }
            }
            
            if (cur.Position == (0, 0) && cur.HasBeenToFinish)
            {
                if (!visited.Contains((cur.Position.X, cur.Position.Y, cur.Minute + 3, true, true)))
                {
                    visited.Add((cur.Position.X, cur.Position.Y, cur.Minute + 3, true, true));
                    queue.Enqueue(new State()
                    {
                        Position = (cur.Position.X, cur.Position.Y),
                        Minute = cur.Minute + 3,
                        HasSnacks = true,
                        HasBeenToFinish = true
                    }, -cur.Position.X - cur.Position.Y + cur.Minute + 3);
                }
            }

            if (cur.Position.Y < 0 || map[(cur.Minute + 1) % loopSize][cur.Position.Y][cur.Position.X] == 0)
            {
                if (!visited.Contains((cur.Position.X, cur.Position.Y, cur.Minute + 1, cur.HasBeenToFinish, cur.HasSnacks)))
                {
                    visited.Add((cur.Position.X, cur.Position.Y, cur.Minute + 1, cur.HasBeenToFinish, cur.HasSnacks));
                    queue.Enqueue(new State()
                    {
                        Position = (cur.Position.X, cur.Position.Y),
                        Minute = cur.Minute + 1,
                        HasSnacks = cur.HasSnacks,
                        HasBeenToFinish = cur.HasBeenToFinish
                    }, -cur.Position.X - cur.Position.Y - (cur.HasSnacks ? width * height : 0) - (cur.HasBeenToFinish ? width * height : 0)+ cur.Minute + 1);
                }
            }

            foreach (var move in _moves)
            {
                var dest = (X: cur.Position.X + move.X, Y: cur.Position.Y + move.Y);
                if (dest.X < 0 || dest.Y < 0 || dest.X >= width || dest.Y >= height) continue;
                if (visited.Contains((dest.X, dest.Y, cur.Minute + 1, cur.HasBeenToFinish, cur.HasSnacks))) continue;
                visited.Add((dest.X, dest.Y, cur.Minute + 1, cur.HasBeenToFinish, cur.HasSnacks));
                var neighbor = map[(cur.Minute + 1) % loopSize][cur.Position.Y + move.Y][cur.Position.X + move.X];
                if (neighbor == 0)
                {
                    queue.Enqueue(new State()
                    {
                        Position = dest,
                        Minute = cur.Minute + 1,
                        HasSnacks = cur.HasSnacks,
                        HasBeenToFinish = cur.HasBeenToFinish
                    }, -dest.X - dest.Y + cur.Minute + 1);
                }
            }
        }

        return best + 1;
    }

    private int ParseInput(char c)
    {
        return c switch
        {
            '^' => (int) Directions.Up,
            '>' => (int) Directions.Right,
            'v' => (int) Directions.Down,
            '<' => (int) Directions.Left,
            '.' => (int) Directions.None,
            _ => throw new Exception()
        };
    }
    
    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}