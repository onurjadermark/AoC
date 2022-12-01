namespace Solutions.Solutions._2020;

public class Day02
{
    public int Part1(string[] inputs)
    {
        var lines = inputs.Select(x => x.Split('-', ':', ' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList());
        var validPasswords = 0;
        foreach (var line in lines)
        {
            var minAmount = int.Parse(line[0]);
            var maxAmount = int.Parse(line[1]);
            var requiredCharacter = line[2];
            var password = line[3];

            var numberOfOccurrences = password.Count(x => x.ToString() == requiredCharacter);
            if (numberOfOccurrences >= minAmount && numberOfOccurrences <= maxAmount) validPasswords++;
        }

        return validPasswords;
    }

    public int Part2(string[] inputs)
    {
        var lines = inputs.Select(x => x.Split('-', ':', ' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList());
        var validPasswords = 0;
        foreach (var line in lines)
        {
            var firstIndex = int.Parse(line[0]) - 1;
            var secondIndex = int.Parse(line[1]) - 1;
            var requiredCharacter = line[2];
            var password = line[3];

            if (password.Length > secondIndex)
            {
                if (password[firstIndex].ToString() == requiredCharacter)
                {
                    if (password[secondIndex].ToString() != requiredCharacter) validPasswords++;
                }
                else if (password[secondIndex].ToString() == requiredCharacter)
                {
                    validPasswords++;
                }
            }
        }

        return validPasswords;
    }
}