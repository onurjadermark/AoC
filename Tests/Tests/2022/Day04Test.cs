using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day04Test
{
    private readonly string[] _sampleInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8".Split(Environment.NewLine).ToArray();

    private Day04 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(2);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(4);
}