using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class Day17Test
{
    private readonly string[] _sampleInput = @"".Split(Environment.NewLine).ToArray();

    private Day17 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(0);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(0);
}