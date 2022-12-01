namespace Solutions.Solutions._2021;

public class Day16
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var package = string.Join(string.Empty,
            input.First().Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
        var usedBits = 0;
        return Calculate(package, part, ref usedBits);
    }

    private long Calculate(string package, int part, ref int usedBits)
    {
        var value = 0L;

        var version = Convert.ToInt64(package.Substring(usedBits, 3), 2);
        usedBits += 3;
        if (part == 1) value = version;

        var type = Convert.ToInt64(package.Substring(usedBits, 3), 2);
        usedBits += 3;

        if (type == 4)
        {
            var number = "";
            while (true)
            {
                var bits = package.Substring(usedBits, 5);
                usedBits += 5;
                number += bits.Substring(1);
                if (bits.StartsWith("0")) break;
            }

            value = part == 1 ? version : Convert.ToInt64(number, 2);
        }
        else
        {
            var l = Convert.ToInt64(package.Substring(usedBits, 1), 2);
            usedBits++;
            if (l == 0)
            {
                var totalSubPacketLength = Convert.ToInt32(package.Substring(usedBits, 15), 2);
                usedBits += 15;
                value += CalculateWithLength(package, part, part == 1 ? Operator.Sum : (Operator) type, ref usedBits,
                    totalSubPacketLength);
            }
            else
            {
                var numSubPackets = Convert.ToInt32(package.Substring(usedBits, 11), 2);
                usedBits += 11;
                value += CalculateWithCount(package, part, part == 1 ? Operator.Sum : (Operator) type, ref usedBits,
                    numSubPackets);
            }
        }

        return value;
    }

    private long CalculateWithLength(string package, int part, Operator type, ref int usedBits,
        int totalSubPacketLength)
    {
        var values = new List<long>();
        var origUsedBits = usedBits;
        while (usedBits - origUsedBits != totalSubPacketLength) values.Add(Calculate(package, part, ref usedBits));

        return Calculate(type, values);
    }

    private long CalculateWithCount(string package, int part, Operator type, ref int usedBits, int numSubPackets)
    {
        var values = new List<long>();
        while (numSubPackets > 0)
        {
            values.Add(Calculate(package, part, ref usedBits));
            numSubPackets--;
        }

        return Calculate(type, values);
    }

    private long Calculate(Operator op, List<long> values)
    {
        return op switch
        {
            Operator.Sum => values.Sum(),
            Operator.Literal => values.Sum(),
            Operator.Product => values.Aggregate((x, y) => x * y),
            Operator.Maximum => values.Max(),
            Operator.Minimum => values.Min(),
            Operator.GreaterThan => values.First() > values.Last() ? 1 : 0,
            Operator.LessThan => values.First() < values.Last() ? 1 : 0,
            Operator.EqualTo => values.First() == values.Last() ? 1 : 0,
            _ => throw new NotImplementedException()
        };
    }

    private enum Operator
    {
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        Literal = 4,
        GreaterThan = 5,
        LessThan = 6,
        EqualTo = 7
    }
}