using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day01Test
{
    private readonly int[] _sampleInput =
    {
        1721,
        979,
        366,
        299,
        675,
        1456
    };

    public Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(514579);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(241861950);
}