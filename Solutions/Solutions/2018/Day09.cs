namespace Solutions.Solutions._2018;

public class Day09
{
    public long Part1(string input)
    {
        var split = input.Split();
        var numPlayers = int.Parse(split[0]);
        var lastMarbleValue = int.Parse(split[6]);

        var marbles = new LinkedList<int>();
        var currentMarble = new LinkedListNode<int>(0);
        marbles.AddFirst(currentMarble);

        var playerPoints = new long[numPlayers];
        var currentPlayer = 1;

        void Next()
        {
            currentMarble = currentMarble!.Next ?? marbles.First;
        }

        void Prev()
        {
            currentMarble = currentMarble!.Previous ?? marbles.Last;
        }

        for (var i = 1; i <= lastMarbleValue; i++)
        {
            if (i % 23 == 0)
            {
                playerPoints[currentPlayer] += i;
                Prev();
                Prev();
                Prev();
                Prev();
                Prev();
                Prev();
                Prev();
                Prev();
                var removedValue = currentMarble!.Value;
                var nextMarble = currentMarble.Next ?? marbles.First;
                nextMarble = nextMarble!.Next ?? marbles.First;
                marbles.Remove(currentMarble);
                currentMarble = nextMarble;
                playerPoints[currentPlayer] += removedValue;
            }
            else
            {
                marbles.AddAfter(currentMarble!, i);
                Next();
                Next();
            }

            currentPlayer = (currentPlayer + 1) % numPlayers;
        }

        return playerPoints.Max();
    }

    public long Part2()
    {
        return Part1("486 players; last marble is worth 7083300 points");
    }
}