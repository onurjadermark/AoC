namespace Solutions.Solutions._2020;

public class Day08
{
    public long Part1(string[] input)
    {
        var value = 0;
        var instructions = input.Select(GetInstruction).ToList();
        var seenInstructions = new HashSet<int>();
        var currentLine = 0;
        while (true)
        {
            if (seenInstructions.Contains(currentLine)) return value;
            seenInstructions.Add(currentLine);
            var currentInstruction = instructions[currentLine];
            switch (currentInstruction.InstructionType)
            {
                case InstructionType.Acc:
                    value += currentInstruction.Value;
                    currentLine++;
                    break;
                case InstructionType.Nop:
                    currentLine++;
                    break;
                default:
                    currentLine += currentInstruction.Value;
                    break;
            }
        }
    }

    public int Part2(string[] input)
    {
        var value = 0;
        var instructions = input.Select(GetInstruction).ToList();
        var seenInstructions = new HashSet<int>();
        var currentLine = 0;
        for (var i = 0; i < instructions.Count; i++)
        {
            var changedInstruction = instructions[i];
            SwitchInstruction(changedInstruction);

            while (true)
            {
                if (seenInstructions.Contains(currentLine)) break;
                seenInstructions.Add(currentLine);

                if (currentLine == instructions.Count) return value;
                var currentInstruction = instructions[currentLine];
                switch (currentInstruction.InstructionType)
                {
                    case InstructionType.Acc:
                        value += currentInstruction.Value;
                        currentLine++;
                        break;
                    case InstructionType.Nop:
                        currentLine++;
                        break;
                    default:
                        currentLine += currentInstruction.Value;
                        break;
                }
            }

            SwitchInstruction(changedInstruction);

            seenInstructions.Clear();
            currentLine = 0;
            value = 0;
        }

        return value;
    }

    private static void SwitchInstruction(Instruction changedInstruction)
    {
        switch (changedInstruction.InstructionType)
        {
            case InstructionType.Jmp:
                changedInstruction.InstructionType = InstructionType.Nop;
                break;
            case InstructionType.Nop:
                changedInstruction.InstructionType = InstructionType.Jmp;
                break;
        }
    }

    private Instruction GetInstruction(string line)
    {
        var split = line.Split(" ");
        return new Instruction
        {
            InstructionType = Enum.Parse<InstructionType>(split[0], true),
            Value = int.Parse(split[1])
        };
    }

    private enum InstructionType
    {
        Nop,
        Acc,
        Jmp
    }

    private class Instruction
    {
        public InstructionType InstructionType { get; set; }
        public int Value { get; set; }
    }
}