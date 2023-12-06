using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day06Test
{
    private readonly string[] _sampleInput = @"Time:      7  15   30
Distance:  9  40  200".Split(Environment.NewLine).ToArray();

    private Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(288);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(71503);
}