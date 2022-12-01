namespace Solutions.Solutions._2021;

public class Day02
{
    public int Part1(string[] input)
    {
        var xPos = 0;
        var yPos = 0;
        foreach (var cur in input)
        {
            var split = cur.Split().Select(x => x.ToLower()).ToList();
            var direction = split[0];
            var size = int.Parse(split[1]);
            switch (direction)
            {
                case "forward":
                    xPos += size;
                    break;
                case "down":
                    yPos += size;
                    break;
                case "up":
                    yPos -= size;
                    break;
            }
        }

        return xPos * yPos;
    }

    public int Part2(string[] input)
    {
        var xPos = 0;
        var yPos = 0;
        var aim = 0;
        foreach (var cur in input)
        {
            var split = cur.Split().Select(x => x.ToLower()).ToList();
            var direction = split[0];
            var size = int.Parse(split[1]);
            switch (direction)
            {
                case "forward":
                    xPos += size;
                    yPos += size * aim;
                    break;
                case "down":
                    aim += size;
                    break;
                case "up":
                    aim -= size;
                    break;
            }
        }

        return xPos * yPos;
    }
}