using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day20Test
{
    private readonly string[] _sampleInput = @"1
2
-3
3
-2
0
4".Split(Environment.NewLine).ToArray();

    private Day20 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(3);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(1623178306);
}