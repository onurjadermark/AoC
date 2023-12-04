namespace Solutions.Solutions._2023
{
    public class Day04
    {
        public int Part1(string[] input)
        {
            return Solve(input, 1);
        }

        public int Part2(string[] input)
        {
            return Solve(input, 2);
        }

        private int Solve(string[] input, int part)
        {
            var sum = 0;
            var numCards = Enumerable.Range(0, input.Length).ToDictionary(i => i, _ => 1);

            foreach (var line in input)
            {
                var id = GetId(line) - 1;
                var winningCards = GetCards(line, 0);
                var myCards = GetCards(line, 1);

                var wins = winningCards.Intersect(myCards).Count();
                if (wins == 0) continue;

                if (part == 1)
                {
                    sum += (int)Math.Pow(2, wins - 1);
                    continue;
                }

                for (var i = id + 1; i < id + wins + 1; i++)
                {
                    if (i > input.Length) break;
                    numCards[i] += numCards[id];
                }
            }

            return part == 1 ? sum : numCards.Sum(x => x.Value);
        }

        private static int GetId(string line)
        {
            return int.Parse(line.Split(':')[0][5..]);
        }

        private static IEnumerable<int> GetCards(string line, int index)
        {
            return line.Split(':')[1].Split('|')[index].Split(" ")
                       .Where(x => !string.IsNullOrWhiteSpace(x))
                       .Select(int.Parse).ToArray();
        }
    }
}
