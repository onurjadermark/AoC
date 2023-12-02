namespace Solutions.Solutions._2023;

public class Day02
{
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
        var sum = 0;

        foreach (var line in input)
        {
            var id = int.Parse(line.Split(":")[0][4..]);
            var tokens = line.Split(":")[1].Split(";");
            
            var possible = true;
            var minRed = 0;
            var minGreen = 0;
            var minBlue = 0;
            
            foreach (var token in tokens)
            {
                var cubes = token.Split(",");
                var red = 0;
                var green = 0;
                var blue = 0;
                
                foreach (var cube in cubes)
                {
                    if (cube.Contains("blue"))
                    {
                        blue = int.Parse(cube.Split(" ")[1]);
                    }

                    if (cube.Contains("green"))
                    {
                        green = int.Parse(cube.Split(" ")[1]);
                    }

                    if (cube.Contains("red"))
                    {
                        red = int.Parse(cube.Split(" ")[1]);
                    }
                }

                if (red > 12 || green > 13 || blue > 14)
                {
                    possible = false;
                }

                if (minRed < red)
                {
                    minRed = red;
                }

                if (minBlue < blue)
                {
                    minBlue = blue;
                }

                if (minGreen < green)
                {
                    minGreen = green;
                }
            }

            if (possible && part == 1)
            {
                sum += id;
            }

            if (part == 2)
            {
                sum += minRed * minBlue * minGreen;
            }
        }

        return sum;
    }
}