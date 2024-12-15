using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day15
{
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
        var (grid, robot, boxes) = ParseGrid(input, part);
        var directions = input.SkipUntil(string.IsNullOrWhiteSpace).SelectMany(x => x).ToArray();
         
        foreach (var direction in directions.Select(DirectionUtils.FromChar))
        {
            if (!HasBoxes(part, boxes, robot.Add(direction)))
            {
                robot = MoveRobot(grid, robot, direction);
                continue;
            }
            
            var boxesToMove = GetBoxesToMove(part, robot, direction, boxes, grid);
            if (IsBlocked(part, boxesToMove, grid, direction)) continue;
            MoveBoxes(boxes, boxesToMove, direction);
            robot = robot.Add(direction);
        }
        
        return boxes.Select(x => 100 * x.Y + x.X).Sum();
    }

    private static bool IsBlocked(int part, HashSet<(int X, int Y)> boxesToMove, Grid<char> grid, (int X, int Y) direction)
    {
        return boxesToMove.Any(x => grid[x.Add(direction)].Value == '#') ||
               part == 2 && boxesToMove.Any(x => grid[x.Add(direction).Add((1, 0))].Value == '#');
    }

    private static bool HasBoxes(int part, HashSet<(int X, int Y)> boxes, (int X, int Y) newPosition)
    {
        return boxes.Contains(newPosition) || (part == 2 && boxes.Contains((newPosition.X - 1, newPosition.Y)));
    }

    private static void MoveBoxes(HashSet<(int X, int Y)> boxes, HashSet<(int X, int Y)> boxesToMove, (int X, int Y) direction)
    {
        boxesToMove.ForEach(x => boxes.Remove(x));
        boxesToMove.Select(x => x.Add(direction)).ForEach(x => boxes.Add(x));
    }

    private static (int X, int Y) MoveRobot(Grid<char> grid, (int X, int Y) robot, (int X, int Y) direction)
    {
        var newRobot = robot.Add(direction);
        return grid[newRobot].Value != '#' ? newRobot : robot;
    }

    private static HashSet<(int X, int Y)> GetBoxesToMove(int part, (int X, int Y) robot, (int X, int Y) direction, HashSet<(int X, int Y)> boxes, Grid<char> grid)
    {
        return part == 1 ? GetSmallBoxesToPush(robot, direction, boxes) :
            direction.Y == 0 ? GetBigBoxesToPushHorizontally(robot, direction, boxes) :
            GetBigBoxesToPushVertically(robot, direction, boxes, grid);
    }

    private static HashSet<(int X, int Y)> GetSmallBoxesToPush((int X, int Y) robot, (int X, int Y) direction, HashSet<(int X, int Y)> boxes)
    {
        var boxesToMove = new HashSet<(int X, int Y)>();
        var cur = robot.Add(direction);
        while (boxes.Contains(cur))
        {
            boxesToMove.Add(cur);
            cur = cur.Add(direction);
        }
        return boxesToMove;
    }

    private static HashSet<(int X, int Y)> GetBigBoxesToPushVertically((int X, int Y) robot, (int X, int Y) direction, HashSet<(int X, int Y)> boxes, Grid<char> grid)
    {
        var boxesToMove = new HashSet<(int X, int Y)>();
        var newPosition = robot.Add(direction);
        var positionsToMove = new List<(int X, int Y)>() { newPosition };
        while (true)
        {
            var boxesToMoveCount = boxesToMove.Count;
            boxes.Where(x => positionsToMove.Contains(x) || positionsToMove.Contains(x.Add((1, 0)))).ToList().ForEach(x => boxesToMove.Add(x));
            positionsToMove = boxesToMove.SelectMany(x => new[] { x.Add(direction), x.Add(direction).Add((1, 0)) }).ToList();
            if (boxesToMove.Count == boxesToMoveCount) break;
        }

        return boxesToMove;
    }

    private static HashSet<(int X, int Y)> GetBigBoxesToPushHorizontally((int X, int Y) robot, (int X, int Y) direction, HashSet<(int X, int Y)> boxes)
    {
        var boxesToMove = new HashSet<(int X, int Y)>();
        var newPosition = robot.Add(direction);

        while (boxes.Contains(newPosition) || boxes.Contains(newPosition.Add(direction)))
        {
            if (boxes.Contains(newPosition))
            {
                boxesToMove.Add(newPosition);
            }

            newPosition = newPosition.Add(direction);
        }

        return boxesToMove;
    }

    private static (Grid<char> grid, (int X, int Y) robot, HashSet<(int X, int Y)> boxes) ParseGrid(string[] input, int part)
    {
        var grid = GridFactory.FromInputStrings((part == 1 ? input : TransformInputForPart2(input))
            .TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToArray());
        var robot = grid.Nodes.Single(x => x.Value == '@').Position;
        var boxes = grid.Nodes.Where(x => x.Value is 'O' or '[').Select(x => x.Position).ToHashSet();
        grid.Nodes.Where(x => x.Value is 'O' or '[' or '@' or ']').ForEach(x => x.Value = '.');
        return (grid, robot, boxes);
    }

    private static string[] TransformInputForPart2(string[] input)
    {
        var result = new List<string>();
        foreach (var line in input.TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToArray())
        {
            var newLine = line.Aggregate("", (cur, ch) => cur + ch switch
            {
                '@' => "@.",
                'O' => "[]",
                '#' => "##",
                _ => ".."
            });
            
            result.Add(newLine);
        }
        
        return result.ToArray();
    }
}