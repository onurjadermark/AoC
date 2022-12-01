namespace Solutions.Solutions._2021;

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
        var numbers = input[0].Split(',').Select(int.Parse).ToList();

        var boards = Enumerable.Range(0, input.Length / 6).Select(x =>
            Enumerable.Range(0, 5).Select(y =>
                Enumerable.Range(0, 5).Select(z => int.Parse(input[2 + 6 * x + y]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)[z])).ToList()).ToList()).ToList();

        var processedNumbers = new List<int>();
        var boardsWon = new List<List<List<int>>>();
        foreach (var number in numbers)
        {
            processedNumbers.Add(number);
            foreach (var board in boards)
                if (board.Any(x => x.All(y => processedNumbers.Contains(y))) ||
                    Enumerable.Range(0, 5).Any(x => board.Select(y => y[x]).All(y => processedNumbers.Contains(y))))
                    boardsWon.Add(board);

            boards.RemoveAll(x => boardsWon.Contains(x));
            if ((part == 1 && boardsWon.Any()) || !boards.Any()) break;
        }

        return boardsWon.Last().Select(x => x.Where(y => !processedNumbers.Contains(y)).Sum()).Sum() *
               processedNumbers.Last();
    }
}