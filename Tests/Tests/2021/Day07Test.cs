using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day07Test
{
    private readonly string[] _sampleInput = "16,1,2,0,4,2,7,1,2,14".Split(Environment.NewLine).ToArray();

    private Day07 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(37);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(168);
}