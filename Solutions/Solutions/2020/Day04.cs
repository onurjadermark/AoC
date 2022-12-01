namespace Solutions.Solutions._2020;

public class Day04
{
    public int Part1(string[] input)
    {
        var numValid = 0;
        var pieces = new Dictionary<string, string>();
        var keys = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl"};
        foreach (var line in input)
            if (string.IsNullOrEmpty(line))
            {
                if (pieces.Count == 7 && keys.All(x => pieces.Any(y => y.Key == x))) numValid++;
                pieces = new Dictionary<string, string>();
            }
            else
            {
                foreach (var s in line.Split(" ").Select(x => x.Split(":")).Where(x => x[0] != "cid"))
                    pieces[s[0]] = s[1];
            }

        if (pieces.Count == 7 && keys.All(x => pieces.Any(y => y.Key == x))) numValid++;

        return numValid;
    }

    public int Part2(string[] input)
    {
        var numValid = 0;
        var pieces = new Dictionary<string, string>();
        var keys = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl"};
        foreach (var line in input)
            if (string.IsNullOrEmpty(line))
            {
                if (IsValidPassport(pieces, keys)) numValid++;
                pieces = new Dictionary<string, string>();
            }
            else
            {
                foreach (var s in line.Split(" ").Select(x => x.Split(":")).Where(x => x[0] != "cid"))
                    pieces[s[0]] = s[1];
            }

        if (IsValidPassport(pieces, keys)) numValid++;

        return numValid;
    }

    private static bool IsValidPassport(Dictionary<string, string> pieces, string[] keys)
    {
        if (pieces.Count == 7 && keys.All(x => pieces.Any(y => y.Key == x)))
        {
            var birthDate = int.Parse(pieces["byr"]);
            if (birthDate < 1920 || birthDate > 2002) return false;
            var issueYear = int.Parse(pieces["iyr"]);
            if (issueYear < 2010 || issueYear > 2020) return false;
            var expirationYear = int.Parse(pieces["eyr"]);
            if (expirationYear < 2020 || expirationYear > 2030) return false;
            var height = pieces["hgt"];
            if (height.Length < 4) return false;
            var height1 = int.Parse(height[..^2]);
            var height2 = height.Substring(height.Length - 2, 2);
            if (height2 == "cm")
                if (height1 < 150 || height1 > 193)
                    return false;
            if (height2 == "in")
                if (height1 < 59 || height1 > 76)
                    return false;

            var hairColor = pieces["hcl"];
            if (!hairColor.StartsWith("#") ||
                !hairColor.Skip(1).All(x => "qwertyuiopasdfghjklzxcvbnm1234567890".Contains(x))) return false;
            var eyeColor = pieces["ecl"];
            var validEyeColors = "amb blu brn gry grn hzl oth".Split();
            if (!validEyeColors.Contains(eyeColor)) return false;
            var pid = pieces["pid"];
            if (pid.Length != 9 || !long.TryParse(pid, out var _)) return false;

            return true;
        }

        return false;
    }
}