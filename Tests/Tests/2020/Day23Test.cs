using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day23Test
{
    private readonly string _sampleInput1 = @"389125467";

    private Day23 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be("67384529");

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be("149245887792");
}