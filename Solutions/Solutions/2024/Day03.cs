namespace Solutions.Solutions._2024
{
    public class Day03
    {
        public long Part1(string[] input)
        {
            return Solve(input, 1);
        }

        public long Part2(string[] input)
        {
            return Solve(input, 2);
        }

        private long Solve(string[] lines, int part)
        {
            var sum = 0L;
            var isEnabled = true;

            foreach (var input in lines)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    if (IsCommandAtIndex(input, i, "mul(") && isEnabled)
                    {
                        sum += GetMultiplicationValue(input, i);
                    }

                    if (part != 2) continue;

                    if (IsCommandAtIndex(input, i, "do()"))
                    {
                        isEnabled = true;
                    }

                    if (IsCommandAtIndex(input, i, "don't()"))
                    {
                        isEnabled = false;
                    }
                }
            }
            
            return sum;
        }

        private static bool IsCommandAtIndex(string input, int index, string command)
        {
            return index + command.Length <= input.Length && input.Substring(index, command.Length) == command;
        }

        private static long GetMultiplicationValue(string input, int index)
        {
            index += 4;
            var end = input.IndexOf(')', index);
            if (end == -1) return 0;
                    
            var numbers = input.Substring(index, end - index).Split(',');
            if (numbers.Length != 2) return 0;
                    
            return int.TryParse(numbers[0], out var num1) && int.TryParse(numbers[1], out var num2) ? num1 * num2 : 0;
        }
    }
}