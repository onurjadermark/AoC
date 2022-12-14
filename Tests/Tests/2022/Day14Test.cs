using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day14Test
{
    private readonly string[] _sampleInput = @"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9".Split(Environment.NewLine).ToArray();

    private Day14 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(24);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(93);
}