using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day19Test
{
    private readonly string[] _sampleInput1 = @"r, wr, b, g, bwu, rb, gb, br

brwrr
bggr
gbbr
rrbgbr
ubwu
bwurrg
brgr
bbrgwb".Split(Environment.NewLine).ToArray();

    private Day19 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(6);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(16);
}