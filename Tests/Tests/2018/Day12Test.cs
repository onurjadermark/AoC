using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day12Test
{
    private const string SampleInput = @"initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";

    public Day12 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(SampleInput).Should().Be(325);

    [Test]
    public void Part2() => GetInstance().Part2(SampleInput).Should().Be(999999999374);
}