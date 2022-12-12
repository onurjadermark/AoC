using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day12Test
{
    private readonly string[] _sampleInput = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi".Split(Environment.NewLine).ToArray();

    private Day12 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(31);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(29);
}