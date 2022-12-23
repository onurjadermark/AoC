namespace Solutions.Solutions._2022;

public class Day23
{
    private static readonly (int, int)[] Directions = {(-1, -1), (0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0)};

    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var elves = new List<Elf>();
        var positions = new HashSet<(int X, int Y)>();
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] == '#')
                {
                    elves.Add(new Elf
                    {
                        Position = (j, i)
                    });
                }
            }
        }
        elves.ForEach(x => positions.Add(x.Position));

        var round = 0;
        while (true)
        {
            var elfMoved = false;
            var directionsToConsider = GetDirections(round);
            foreach (var elf in elves)
            {
                var neighbors = Directions.Select(y => (y.Item1 + elf.Position.X, y.Item2 + elf.Position.Y));
                if (neighbors.All(x => !positions.Contains(x))) continue;
                foreach (var directions in directionsToConsider)
                {
                    var considered = directions.Select(x => (elf.Position.X + x.Item1, elf.Position.Y + x.Item2)).ToList();
                    if (considered.Any(x => positions.Contains(x))) continue;
                    elf.Target = considered.ElementAt(1);
                    break;
                }
            }

            var targets = new Dictionary<(int X, int Y), int>();
            foreach (var elf in elves)
            {
                if (elf.Target != null)
                {
                    if (!targets.ContainsKey(elf.Target.Value)) targets[elf.Target.Value] = 0;
                    targets[elf.Target.Value]++;
                }
            }
            foreach (var elf in elves)
            {
                if (elf.Target != null && targets[elf.Target!.Value] == 1)
                {
                    positions.Remove(elf.Position);
                    elf.Position = elf.Target!.Value;
                    positions.Add(elf.Position);
                    elfMoved = true;
                }
            }

            foreach (var elf in elves) elf.Target = null;

            round++;

            if (round == 10 && part == 1) return (elves.Max(x => x.Position.X) - elves.Min(x => x.Position.X) + 1) *
                (elves.Max(x => x.Position.Y) - elves.Min(x => x.Position.Y) + 1) - elves.Count;
            if (!elfMoved && part == 2) return round;
        }
    }

    private static (int, int)[][] GetDirections(int round)
    {
        var result = new List<(int, int)[]>
        {
            new[] {Directions[0], Directions[1], Directions[2]},
            new[] {Directions[4], Directions[5], Directions[6]},
            new[] {Directions[6], Directions[7], Directions[0]},
            new[] {Directions[2], Directions[3], Directions[4]}
        };
        return result.Skip(round % 4).Concat(result.Take(round % 4)).ToArray();
    }

    private class Elf
    {
        public (int X, int Y) Position { get; set; }
        public (int X, int Y)? Target { get; set; }
    }
}