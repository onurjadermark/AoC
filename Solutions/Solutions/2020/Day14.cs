using System.Text;

namespace Solutions.Solutions._2020;

public class Day14
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var instructions = input.Select(x => new Instruction(x));

        var currentMask = "";
        var memory = new Dictionary<string, long>();
        foreach (var instruction in instructions)
            if (instruction.Type == "mask")
            {
                currentMask = instruction.Value;
            }
            else
            {
                if (part == 1)
                {
                    var bits = Convert.ToString(int.Parse(instruction.Value), 2).PadLeft(36, '0');
                    var sb = new StringBuilder();
                    for (var i = 0; i < currentMask.Length; i++)
                    {
                        var curMask = currentMask[i];
                        var curBit = bits[i];
                        sb.Append(curMask == 'X' ? curBit : curMask);
                    }

                    var result = sb.ToString();

                    memory[instruction.Address.ToString()] = Convert.ToInt64(result, 2);
                }
                else
                {
                    var bits = Convert.ToString(instruction.Address, 2).PadLeft(36, '0');
                    var sb = new StringBuilder();
                    for (var i = 0; i < currentMask.Length; i++)
                    {
                        var curMask = currentMask[i];
                        var curBit = bits[i];
                        if (curMask == '0')
                            sb.Append(curBit);
                        else if (curMask == '1')
                            sb.Append('1');
                        else
                            sb.Append('X');
                    }

                    var result = sb.ToString();

                    var indexes = new List<int>();
                    var indexFactors = new List<long>();
                    for (var i = 0; i < 36; i++)
                    {
                        var cur = result[i];
                        if (cur == 'X')
                        {
                            indexes.Add(i);
                            indexFactors.Add((long) Math.Pow(2, 36 - i - 1));
                        }
                    }

                    var baseIndex = Convert.ToInt64(result.Replace('X', '0'), 2);
                    var addresses = new List<long> {baseIndex};
                    foreach (var indexFactor in indexFactors)
                    foreach (var address in addresses.ToList())
                        addresses.Add(address + indexFactor);

                    foreach (var address in addresses) memory[address.ToString()] = int.Parse(instruction.Value);
                }
            }

        return memory.Values.Sum();
    }

    internal class Instruction
    {
        public Instruction(string s)
        {
            var first = s.Split("=")[0];
            if (first.StartsWith("mask"))
            {
                Type = "mask";
            }
            else
            {
                Type = "mem";
                var address = first.Split('[', ']', StringSplitOptions.RemoveEmptyEntries).Last().Trim();
                Address = int.Parse(address[..^1].Trim());
            }

            Value = s.Split("=")[1].Trim();
        }

        public string Type { get; set; }
        public int Address { get; set; }
        public string Value { get; set; }
    }
}