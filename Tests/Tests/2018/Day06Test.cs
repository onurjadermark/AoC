using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day06Test
{
    private readonly string _sampleInput = @"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9";

    public Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput.Split('\n')).Should().Be(17);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput.Split('\n')).Should().Be(16);
}