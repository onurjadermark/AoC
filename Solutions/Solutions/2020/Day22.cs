namespace Solutions.Solutions._2020;

public class Day22
{
    public long Part1(string input)
    {
        return Solve(input, 1);
    }

    public long Part2(string input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string input, int part)
    {
        var split = input.Split("\r\n\r\n").Select(x => x.Trim()).ToList();

        var cards1 = split.ElementAt(0).Split("\n").Select(x => x.Trim()).Skip(1).Select(int.Parse).ToList();
        var cards2 = split.ElementAt(1).Split("\n").Select(x => x.Trim()).Skip(1).Select(int.Parse).ToList();

        var winner = Recurse(cards1, cards2, part);
        if (winner == 0) throw new Exception();

        long result = 0;

        var cards = cards1.Any() ? cards1 : cards2;
        cards.Reverse();
        for (var i = 0; i < cards.Count; i++) result += cards.ElementAt(i) * (i + 1);

        return result;
    }

    private static int Recurse(List<int> cards1, List<int> cards2, int part)
    {
        var configurations = new HashSet<string>();
        while (cards1.Any() && cards2.Any())
        {
            var key = string.Join(",", cards1) + ":" + string.Join(",", cards2);
            if (configurations.Contains(key)) return 1;

            configurations.Add(key);

            var next1 = cards1.First();
            var next2 = cards2.First();

            cards1.Remove(next1);
            cards2.Remove(next2);

            if (part == 2 && cards1.Count >= next1 && cards2.Count >= next2)
            {
                var newCards1 = cards1.Take(next1).ToList();
                var newCards2 = cards2.Take(next2).ToList();
                var winner = Recurse(newCards1, newCards2, part);
                if (winner == 1)
                {
                    cards1.Add(next1);
                    cards1.Add(next2);
                }
                else
                {
                    cards2.Add(next2);
                    cards2.Add(next1);
                }
            }
            else
            {
                if (next1 > next2)
                {
                    cards1.Add(next1);
                    cards1.Add(next2);
                }
                else
                {
                    cards2.Add(next2);
                    cards2.Add(next1);
                }
            }
        }

        return cards1.Any() ? 1 : 2;
    }
}