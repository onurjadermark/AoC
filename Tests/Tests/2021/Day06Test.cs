using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day06Test
{
    private readonly string[] _sampleInput = "3,4,3,1,2".Split(Environment.NewLine).ToArray();

    private Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(5934);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(26984457539);
}