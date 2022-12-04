namespace Solutions.Solutions._2022;

public class Day04
{
    public int Part1(string[] input)
    {
        return Solve(input, false);
    }

    public int Part2(string[] input)
    {
        return Solve(input, true);
    }

    private static int Solve(string[] input, bool isPartTwo)
    {
        var result = 0;
        foreach (var line in input)
        {
            var sections = line.Split(",");
            var firstElf = sections[0].Split("-").Select(int.Parse).ToList();
            var secondElf = sections[1].Split("-").Select(int.Parse).ToList();
            var firstAssignments = Enumerable.Range(firstElf[0], firstElf[1] - firstElf[0] + 1).ToList();
            var secondAssignments = Enumerable.Range(secondElf[0], secondElf[1] - secondElf[0] + 1).ToList();
            if (isPartTwo)
            {
                if (firstAssignments.Any(x => secondAssignments.Contains(x)) ||
                    secondAssignments.Any(x => firstAssignments.Contains(x)))
                {
                    result++;
                }
            }
            else
            {
                if (firstAssignments.All(x => secondAssignments.Contains(x)) ||
                    secondAssignments.All(x => firstAssignments.Contains(x)))
                {
                    result++;
                }
            }
        }

        return result;
    }
}