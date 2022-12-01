using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day22Test
{
    private readonly string _sampleInput1 = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

    private Day22 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(306);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(291);
}