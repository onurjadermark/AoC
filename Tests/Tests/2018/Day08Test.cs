using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day08Test
{
    private readonly string _sampleInput = @"2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

    public Day08 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(138);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(66);
}