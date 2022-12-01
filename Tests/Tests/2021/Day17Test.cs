using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day17Test
{
    private readonly string[] _sampleInput = @"target area: x=20..30, y=-10..-5".Split(Environment.NewLine).ToArray();

    private Day17 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(45);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(112);
}