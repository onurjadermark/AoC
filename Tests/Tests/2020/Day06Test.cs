using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day06Test
{
    private readonly string _sampleInput =
        @"abc

a
b
c

ab
ac

a
a
a
a

b";

    private Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput.Split('\n')).Should().Be(11);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput.Split('\n')).Should().Be(6);
}