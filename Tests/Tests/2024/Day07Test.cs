using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day07Test
{
    private readonly string[] _sampleInput1 = @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20".Split(Environment.NewLine).ToArray();

    private Day07 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(3749);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(11387);
}