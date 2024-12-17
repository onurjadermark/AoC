namespace Solutions.Solutions._2024;

public class Day17
{
    public string Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public string Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private string Solve(string[] input, int part)
    {
        var registers = Enumerable.Range(0, 3).Select(x => ParseRegister(input[x])).ToArray();
        var program = input.Skip(4).Single().Split(':')[1].Split(',').Select(long.Parse).ToArray();

        return part == 1 ? string.Join(",", Execute(registers, program)) : CalculateA(program).ToString();
    }

    private static long CalculateA(long[] output)
    {
        var a = 0L;
        for (var i = output.Length - 1; i >= 0; i--)
        {
            a <<= 3;
            var target = output.Skip(i).ToList();
            while (true)
            {
                var cur = Execute([a, 0, 0], output);
                if (cur.SequenceEqual(target)) break;
                a++;
            }
        }

        return a;
    }

    private static long[] Execute(long[] registers, long[] program)
    {
        var output = new List<long>();
        for (var ip = 0L; ip < program.Length; ip += 2)
        {
            var opcode = program[ip];
            var operand = program[ip + 1];
            var comboOperand = GetComboOperand(operand, registers);

            switch (opcode)
            {
                case 0:
                    registers[0] = DividePow(registers[0], comboOperand);
                    break;
                case 1:
                    registers[1] ^= operand;
                    break;
                case 2:
                    registers[1] = comboOperand % 8;
                    break;
                case 3:
                    if (registers[0] != 0) ip = operand - 2;
                    break;
                case 4:
                    registers[1] ^= registers[2];
                    break;
                case 5:
                    output.Add(comboOperand % 8);
                    break;
                case 6:
                    registers[1] = DividePow(registers[0], comboOperand);
                    break;
                case 7:
                    registers[2] = DividePow(registers[0], comboOperand);
                    break;
                default: throw new Exception();
            }
        }

        return output.ToArray();
    }

    private static long GetComboOperand(long val, long[] registers) => val switch
    {
        0 => 0,
        1 => 1,
        2 => 2,
        3 => 3,
        4 => registers[0],
        5 => registers[1],
        6 => registers[2],
        7 => long.MaxValue,
        _ => throw new Exception()
    };

    private static long DividePow(long register, long comboOperand)
    {
        return (long) (register / Math.Pow(2, comboOperand));
    }

    private static long ParseRegister(string line)
    {
        return long.Parse(line.Split(':')[1].Trim());
    }
}