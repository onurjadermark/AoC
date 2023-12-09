using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day09Test
{
    private readonly string[] _sampleInput = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45".Split(Environment.NewLine).ToArray();

    private Day09 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(114);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(2);
}