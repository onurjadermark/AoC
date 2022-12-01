using System.Numerics;

namespace Solutions.Solutions._2021;

public class Day06
{
    public BigInteger Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public BigInteger Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private BigInteger Solve(string[] input, int part)
    {
        var state = InitializeState(input.Single());
        for (var i = 0; i < (part == 1 ? 80 : 256); i++) state = GetNewState(state);

        return GetSum(state);
    }

    private static Dictionary<int, BigInteger> InitializeState(string input)
    {
        var state = new Dictionary<int, BigInteger>();
        Enumerable.Range(0, 8).ToList().ForEach(x => state[x] = 0);
        foreach (var fish in input.Split(",").Select(int.Parse).ToList()) state[fish] += 1;

        return state;
    }

    private static Dictionary<int, BigInteger> GetNewState(Dictionary<int, BigInteger> state)
    {
        var newState = new Dictionary<int, BigInteger>();
        foreach (var (age, count) in state)
        {
            var newAge = age;
            if (age == 0)
            {
                newAge = 6;
                newState[8] = newState.ContainsKey(8) ? newState[8] + count : count;
            }
            else
            {
                newAge--;
            }

            newState[newAge] = newState.ContainsKey(newAge) ? newState[newAge] + count : count;
        }

        return newState;
    }

    private static BigInteger GetSum(Dictionary<int, BigInteger> state)
    {
        BigInteger result = 0;
        foreach (var fishGroup in state) result += fishGroup.Value;

        return result;
    }
}