namespace Solutions.Solutions._2018;

public class Day01
{
    public int Part1(int[] numbers)
    {
        return numbers.Sum();
    }

    public int Part2(int[] numbers)
    {
        var seenFrequencies = new HashSet<int>();
        var currentIndex = 0;
        var currentFrequency = 0;
        while (true)
        {
            if (seenFrequencies.Contains(currentFrequency)) return currentFrequency;
            seenFrequencies.Add(currentFrequency);
            var currentNumber = numbers[currentIndex];
            currentFrequency += currentNumber;
            currentIndex++;
            if (currentIndex == numbers.Length) currentIndex = 0;
        }
    }
}