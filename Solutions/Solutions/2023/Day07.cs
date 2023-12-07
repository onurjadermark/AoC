namespace Solutions.Solutions._2023;

public class Day07
{
    private static int _part;

    public int Part1(string[] input)
    {
        _part = 1;
        return Solve(input);
    }

    public int Part2(string[] input)
    {
        _part = 2;
        return Solve(input);
    }

    private static int Solve(IEnumerable<string> input)
    {
        var players = input.Select(x =>
        {
            var parts = x.Split(" ");
            return new Player
            {
                Cards = new Cards(parts[0]),
                Bid = int.Parse(parts[1])
            };
        }).ToList();

        return players.OrderBy(x => x.Cards).Select((hand, index) => (players.Count - index) * hand.Bid).Sum();
    }

    private enum Hand
    {
        FiveOfAKind = 1,
        FourOfAKind = 2,
        FullHouse = 3,
        ThreeOfAKind = 4,
        TwoPairs = 5,
        OnePair = 6,
        HighCard = 7
    }

    public class Cards : IComparable<Cards>
    {
        public Cards(string value)
        {
            Value = value;
            Hand = GetHand();
        }

        private string Value { get; }

        private Hand Hand { get; }

        public int CompareTo(Cards? other)
        {
            var handComparison = Hand.CompareTo(other!.Hand);
            return handComparison != 0 ? handComparison : string.Compare(GetSortingOrder(Value), GetSortingOrder(other.Value), StringComparison.Ordinal);
        }

        private Hand GetHand()
        {
            var jokerCount = GetJokerCount(Value);
            var hasWildcard = HasWildcard(Value);
            return HasFiveOfAKind(Value) ? Hand.FiveOfAKind :
                HasFourOfAKind(Value) ? hasWildcard ? Hand.FiveOfAKind : Hand.FourOfAKind :
                HasFullHouse(Value) ? hasWildcard ? Hand.FiveOfAKind : Hand.FullHouse :
                HasThreeOfAKind(Value) ? hasWildcard ? Hand.FourOfAKind : Hand.ThreeOfAKind :
                HasTwoPairs(Value) ? hasWildcard ? jokerCount == 2 ? Hand.FourOfAKind : Hand.FullHouse : Hand.TwoPairs :
                HasOnePair(Value) ? hasWildcard ? Hand.ThreeOfAKind : Hand.OnePair :
                hasWildcard ? Hand.OnePair : Hand.HighCard;
        }

        private static int GetJokerCount(string card) => card.Count(x => x == 'J');
        private static bool HasFiveOfAKind(string card) => card.Any(x => card.Count(y => y == x) == 5);
        private static bool HasFourOfAKind(string card) => card.Any(x => card.Count(y => y == x) == 4);
        private static bool HasFullHouse(string card) => card.Any(x => card.Count(y => y == x) == 3) && card.Any(x => card.Count(y => y == x) == 2);
        private static bool HasThreeOfAKind(string card) => card.Any(x => card.Count(y => y == x) == 3) && card.All(x => card.Count(y => y == x) != 2);
        private static bool HasTwoPairs(string card) => card.GroupBy(x => x).Count(x => x.Count() == 2) == 2;
        private static bool HasOnePair(string card) => card.Any(x => card.Count(y => y == x) == 2) && card.GroupBy(x => x).Count() == 4;
        private static bool HasWildcard(string card) => _part == 2 && card.Any(x => x == 'J');
        private static string GetSortingOrder(string card) => string.Join("", card.Select(GetSortingOrder));

        private static char GetSortingOrder(char c)
        {
            return c switch
            {
                'A' => 'A',
                'K' => 'B',
                'Q' => 'C',
                'J' => _part == 2 ? 'Z' : 'D',
                'T' => 'E',
                '9' => 'F',
                '8' => 'G',
                '7' => 'H',
                '6' => 'I',
                '5' => 'J',
                '4' => 'K',
                '3' => 'L',
                '2' => 'M',
                _ => throw new Exception()
            };
        }
    }

    public class Player
    {
        public required Cards Cards { get; init; }
        public int Bid { get; init; }
    }
}