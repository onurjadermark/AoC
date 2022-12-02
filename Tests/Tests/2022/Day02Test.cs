using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day02Test
{
    private readonly string[] _sampleInput = @"A Y
B X
C Z".Split(Environment.NewLine).ToArray();

    private Day02 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(15);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(12);
}