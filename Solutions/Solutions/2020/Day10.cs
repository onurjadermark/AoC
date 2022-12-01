namespace Solutions.Solutions._2020;

public class Day10
{
    public long Part1(string[] input)
    {
        var voltages = input.Select(int.Parse).ToList();
        var deviceVoltage = voltages.Max() + 3;
        voltages.Add(deviceVoltage);
        voltages.Add(0);
        voltages.Sort();
        var last = 0;
        var differences = new int[4];
        foreach (var current in voltages)
        {
            differences[current - last]++;
            last = current;
        }

        long result = 1;
        foreach (var cur in differences)
        {
            if (cur == 0) continue;
            result *= cur;
        }

        return result;
    }

    public long Part2(string[] input)
    {
        var voltages = input.Select(int.Parse).ToList();
        var deviceVoltage = voltages.Max() + 3;
        voltages.Add(deviceVoltage);
        voltages.Add(0);
        voltages.Sort();

        var combinations = new long[voltages.Count];
        combinations[0] = 1;
        for (var i = 1; i < voltages.Count; i++)
        {
            if (voltages[i] - voltages[i - 1] <= 3) combinations[i] += combinations[i - 1];
            if (i > 1 && voltages[i] - voltages[i - 2] <= 3) combinations[i] += combinations[i - 2];
            if (i > 2 && voltages[i] - voltages[i - 3] <= 3) combinations[i] += combinations[i - 3];
        }

        return combinations[voltages.Count - 1];
    }
}