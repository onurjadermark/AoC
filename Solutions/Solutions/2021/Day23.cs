using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day23
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
        var state = GetState(input, part);
        var allMoves = GetMoves(state);
        var queue = new PriorityQueue<int[], int>();
        queue.Enqueue(state, GetCost(state));
        return Solve(queue, allMoves);
    }

    private static long GetHashCode(int[] state, bool skipLast)
    {
        return state.SkipLast(skipLast ? 1 : 0)
            .Aggregate(state.Length, (current, val) => unchecked(current * 314159 + val));
    }

    private long Solve(PriorityQueue<int[], int> queue, Dictionary<int, int[]> allMoves)
    {
        var seen = new HashSet<long>();
        var memo = new Dictionary<long, int>();
        while (true)
        {
            queue.TryDequeue(out var state, out _);

            if (state == null) return -1;

            var hashCode = GetHashCode(state, false);
            if (seen.Contains(hashCode)) continue;
            seen.Add(hashCode);

            var hashCodeSkip = GetHashCode(state, true);
            if (memo.ContainsKey(hashCodeSkip))
            {
                var oldCost = memo[hashCodeSkip];
                if (oldCost < state[^1]) continue;
            }

            memo[hashCodeSkip] = state[^1];

            if (IsComplete(state)) return state[^1];

            for (var fromPos = 0; fromPos < state.Length - 1; fromPos++)
            {
                var node = state[fromPos];
                if (node is 10 or > 3) continue;
                var moves = allMoves[fromPos];
                var fromPosX = GetX(fromPos);

                for (var i = 0; i < moves.Length; i++)
                {
                    var toPos = moves[i];
                    if (state[toPos] != 10) continue;
                    var validMove = true;
                    var toPosX = GetX(toPos);

                    if (fromPos < 11)
                    {
                        if (GetTargetX(state[fromPos]) != toPosX) validMove = false;

                        for (var j = 1; j <= GetY(toPos); j++)
                            if (state[11 + (j - 1) * 4 + (toPos - 11) % 4] != 10)
                            {
                                validMove = false;
                                break;
                            }
                    }
                    else
                    {
                        for (var j = 1; j < GetY(fromPos); j++)
                        {
                            if (state[fromPos - 4 * j] == 10) continue;
                            validMove = false;
                            break;
                        }
                    }

                    for (var j = Math.Min(toPosX, fromPosX); j <= Math.Max(toPosX, fromPosX); j++)
                        if (j != fromPosX && state[j] != 10)
                        {
                            validMove = false;
                            break;
                        }

                    if (!validMove) continue;
                    var newState = (int[]) state.Clone();
                    newState[^1] += (int) Math.Pow(10, newState[fromPos]) *
                                    (Math.Abs(fromPosX - toPosX) + Math.Abs(GetY(fromPos) - GetY(toPos)));
                    newState[toPos] = toPos < 11 ? newState[fromPos] : newState[fromPos] + 4;
                    newState[fromPos] = 10;
                    queue.Enqueue(newState, GetCost(newState));
                }
            }
        }
    }

    private int GetX(int pos)
    {
        switch (pos)
        {
            case 11:
            case 15:
            case 19:
            case 23:
                return 2;
            case 12:
            case 16:
            case 20:
            case 24:
                return 4;
            case 13:
            case 17:
            case 21:
            case 25:
                return 6;
            case 14:
            case 18:
            case 22:
            case 26:
                return 8;
            default:
                return pos;
        }
    }

    private int GetY(int pos)
    {
        return pos switch
        {
            < 11 => 0,
            < 15 => 1,
            < 19 => 2,
            < 23 => 3,
            < 27 => 4,
            _ => throw new Exception()
        };
    }

    private static int GetTargetX(int value)
    {
        switch (value)
        {
            case 0:
            case 4:
                return 2;
            case 1:
            case 5:
                return 4;
            case 2:
            case 6:
                return 6;
            case 3:
            case 7:
                return 8;
            default:
                throw new Exception();
        }
    }

    private static int[] GetState(string[] input, int part)
    {
        if (part == 2)
            input = input.Take(3).Concat(new[] {"  #D#C#B#A#", "  #D#B#A#C#"}).Concat(input.Skip(3)).ToArray();

        var state = new int[11 + (part == 1 ? 8 : 16) + 1];
        for (var i = 0; i < 11; i++) state[i] = 10;

        for (var i = 0; i < 4; i++)
        for (var j = 0; j < (part == 1 ? 2 : 4); j++)
        {
            var val = input[j + 2][i * 2 + 3];
            state[11 + i + j * 4] = val - 'A';
        }

        return state;
    }

    private static Dictionary<int, int[]> GetMoves(int[] state)
    {
        var moves = new Dictionary<int, int[]>();
        var targetX = new[] {2, 4, 6, 8};
        for (var i = 0; i < state.Length - 1; i++)
        {
            var cur = new List<int>();
            if (i < 11) //y = 0
                Enumerable.Range(11, state.Length - 1 - 11).ForEach(x => cur.Add(x));
            else // y > 0
                Enumerable.Range(0, 11).Except(targetX).ForEach(x => cur.Add(x));

            moves[i] = cur.ToArray();
        }

        return moves;
    }

    private int GetCost(int[] state)
    {
        var cost = 0;

        for (var i = 0; i < state.Length - 1; i++)
        {
            if (state[i] == 10) continue;
            var curX = GetX(i);
            var curY = GetY(i);
            var targetX = GetTargetX(state[i] % 4);
            var targetY = 1;
            var xDiff = Math.Abs(targetX - curX);
            var yDiff = curX == targetX ? Math.Abs(targetY - curY) : targetY + curY;
            cost += (xDiff + yDiff) * (int) Math.Pow(10, state[i] % 4);
            if (curX == targetX && curY > 1) cost -= (int) Math.Pow(10, state[i] % 4) * (curY - 1);
        }

        return cost + state[^1];
    }

    private bool IsComplete(int[] state)
    {
        for (var i = 11; i < state.Length - 1; i++)
        {
            if (state[i] == 10) return false;
            if (GetX(i) != GetTargetX(state[i])) return false;
        }

        return true;
    }
}