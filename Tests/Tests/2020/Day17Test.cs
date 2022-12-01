using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day17Test
{
    private readonly string _sampleInput1 = @".#.
..#
###";

    private Day17 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(112);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(848);
}