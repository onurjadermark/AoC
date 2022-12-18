using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day18Test
{
    private readonly string[] _sampleInput = @"2,2,2
1,2,2
3,2,2
2,1,2
2,3,2
2,2,1
2,2,3
2,2,4
2,2,6
1,2,5
3,2,5
2,1,5
2,3,5".Split(Environment.NewLine).ToArray();

    private Day18 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(64);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(58);
}