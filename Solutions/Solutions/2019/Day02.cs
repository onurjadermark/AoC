namespace Solutions.Solutions._2019;

public class Day02
{
    public int Part1(string[] input)
    {
        var program = input[0].Split(",").Select(int.Parse).ToArray();
        program[1] = 12;
        program[2] = 2;
        var intcode = new Intcode(program);
        var result = intcode.Run();
        return result[1];
    }

    public int Part2(string[] input)
    {
        var program = input[0].Split(",").Select(int.Parse).ToArray();
        var found = 0;
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
            {
                program[1] = i;
                program[2] = j;
                var intcode = new Intcode(program);
                var result = intcode.TryRun();
                if (result[1] == 19690720)
                {
                    found = 100 * i + j;
                    break;
                }
            }

            if (found > 0) break;
        }

        return found;
    }
}