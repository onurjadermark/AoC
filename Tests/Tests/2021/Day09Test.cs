using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day09Test
{
    private readonly string[] _sampleInput = @"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine).ToArray();

    private Day09 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(15);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(1134);
}