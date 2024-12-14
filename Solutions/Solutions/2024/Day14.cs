namespace Solutions.Solutions._2024;

public class Day14
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private bool CheckTree(List<Robot> robots)
    {
        for (var j = 0; j < robots.Count - 8; j++)
        {
            var found = true;

            for (var i = 1; i <= 8; i++)
            {
                if (robots[j + i].X - robots[j].X == i) continue;
                found = false;
                break;
            }

            if (found) return true;
        }

        return false;
    }

    private int Solve(string[] input, int part)
    {
        var width = input.Length == 12 ? 11 : 101;
        var height = input.Length == 12 ? 7 : 103;

        var robots = ParseRobots(input);

        for (var i = 0; i < (part == 1 ? 100 : 10000); i++)
        {
            foreach (var robot in robots)
            {
                robot.X = (robot.X + robot.Vx + width) % width;
                robot.Y = (robot.Y + robot.Vy + height) % height;
            }

            if (part != 2) continue;

            robots = robots.OrderBy(r => r.Y).ThenBy(r => r.X).ToList();
            if (!CheckTree(robots)) continue;
            DumpImage(robots);
            return i + 1;
        }

        var quads = new int[2, 2];
        foreach (var robot in robots)
        {
            if (robot.X == width / 2 || robot.Y == height / 2) continue;
            var x = robot.X > width / 2 ? 1 : 0;
            var y = robot.Y > height / 2 ? 1 : 0;
            quads[x, y]++;
        }

        return quads[0, 0] * quads[1, 1] * quads[0, 1] * quads[1, 0];
    }

    private static List<Robot> ParseRobots(string[] input)
    {
        var robots = input.Select(line =>
        {
            var parts = line.Split(' ');
            var x = int.Parse(parts[0].Split(',')[0][2..]);
            var y = int.Parse(parts[0].Split(',')[1]);
            var vx = int.Parse(parts[1].Split(',')[0][2..]);
            var vy = int.Parse(parts[1].Split(',')[1]);
            return new Robot {X = x, Y = y, Vx = vx, Vy = vy};
        }).ToList();
        return robots;
    }

    private static void DumpImage(List<Robot> robots)
    {
        Console.WriteLine();
        
        var y = 0;
        var x = 0;
        foreach (var robot in robots)
        {
            if (robot.Y != y)
            {
                Console.WriteLine();
                y = robot.Y;
                x = 0;
            }

            while (robot.X != x)
            {
                Console.Write(' ');
                x++;
            }

            Console.Write('#');
            x++;
        }

        Console.WriteLine();
    }

    private class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Vx { get; init; }
        public int Vy { get; init; }
    }
}