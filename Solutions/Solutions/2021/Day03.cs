namespace Solutions.Solutions._2021;

public class Day03
{
    public int Part1(string[] input)
    {
        var lines = input;
        var lineLength = lines.First().Length;
        var gamma = "";
        var epsilon = "";

        for (var i = 0; i < lineLength; i++)
        {
            var count0 = lines.Count(x => x[i] == '0');
            var count1 = lines.Count(x => x[i] == '1');
            gamma += count0 > count1 ? '0' : '1';
            epsilon += count0 > count1 ? '1' : '0';
        }

        return ToDecimal(gamma) * ToDecimal(epsilon);
    }

    public int Part2(string[] input)
    {
        var lines = input;
        var lineLength = lines.First().Length;

        var possibleValuesForOxygen = lines.ToList();
        var possibleValuesForCo2 = lines.ToList();

        for (var i = 0; i < lineLength; i++)
        {
            var count0 = possibleValuesForOxygen.Count(x => x[i] == '0');
            var count1 = possibleValuesForOxygen.Count(x => x[i] == '1');
            var valueToKeep = count0 == count1 ? '1' : count0 > count1 ? '0' : '1';
            possibleValuesForOxygen = possibleValuesForOxygen.Where(x => x[i] == valueToKeep).ToList();

            count0 = possibleValuesForCo2.Count(x => x[i] == '0');
            count1 = possibleValuesForCo2.Count(x => x[i] == '1');
            valueToKeep = count0 == count1 ? '0' : count0 > count1 ? '1' : '0';
            possibleValuesForCo2 = possibleValuesForCo2
                .Where(x => possibleValuesForCo2.Count == 1 || x[i] == valueToKeep).ToList();
        }

        return ToDecimal(possibleValuesForOxygen.Single()) * ToDecimal(possibleValuesForCo2.Single());
    }

    private static int ToDecimal(string binary)
    {
        return int.Parse(Convert.ToInt32(binary, 2).ToString());
    }
}