using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day03Test
{
    private readonly string[] _sampleInput = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010".Split(Environment.NewLine).ToArray();

    private Day03 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(198);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(230);
}