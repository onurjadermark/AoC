namespace Solutions.Solutions._2020;

public class Day12
{
    private static readonly (int X, int Y) North = (0, -1);
    private static readonly (int X, int Y) East = (1, 0);
    private static readonly (int X, int Y) South = (0, 1);
    private static readonly (int X, int Y) West = (-1, 0);

    private static readonly Dictionary<((int X, int Y), char D), (int, int)> Turns = new()
    {
        {(East, 'R'), South},
        {(South, 'R'), West},
        {(West, 'R'), North},
        {(North, 'R'), East},
        {(East, 'L'), North},
        {(North, 'L'), West},
        {(West, 'L'), South},
        {(South, 'L'), East}
    };

    private static readonly Dictionary<char, (int X, int Y)> Moves = new()
    {
        {'N', North},
        {'E', East},
        {'S', South},
        {'W', West}
    };

    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var wayPoint = part == 1 ? (X: 1, Y: 0) : (X: 10, Y: -1);
        var instructions = input.Select(x => new Instruction(x)).ToList();
        var (posX, posY) = (0, 0);

        foreach (var instruction in instructions)
            switch (instruction.Type)
            {
                case 'R':
                case 'L':
                {
                    for (var i = 0; i < instruction.Value / 90; i++)
                        if (part == 1)
                            wayPoint = Turns[(wayPoint, instruction.Type)];
                        else
                            wayPoint = instruction.Type switch
                            {
                                'L' => (wayPoint.Y, -wayPoint.X),
                                'R' => (-wayPoint.Y, wayPoint.X),
                                _ => wayPoint
                            };

                    break;
                }
                case 'F':
                {
                    for (var i = 0; i < instruction.Value; i++)
                    {
                        posX += wayPoint.X;
                        posY += wayPoint.Y;
                    }

                    break;
                }
                default:
                {
                    var (x, y) = Moves[instruction.Type];
                    for (var i = 0; i < instruction.Value; i++)
                        if (part == 1)
                        {
                            posX += x;
                            posY += y;
                        }
                        else
                        {
                            wayPoint.X += x;
                            wayPoint.Y += y;
                        }

                    break;
                }
            }

        return Math.Abs(posX) + Math.Abs(posY);
    }

    internal class Instruction
    {
        public Instruction(string s)
        {
            Type = s[0];
            Value = int.Parse(string.Join("", s.Skip(1)));
        }

        public char Type { get; set; }
        public int Value { get; set; }
    }
}