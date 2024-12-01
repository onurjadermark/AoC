using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day01Test
{
    private readonly string[] _sampleInput1 = @"3   4
4   3
2   5
1   3
3   9
3   3".Split(Environment.NewLine).ToArray();

    private Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(11);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(31);
}