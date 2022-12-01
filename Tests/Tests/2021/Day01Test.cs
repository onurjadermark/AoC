using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day01Test
{
    private readonly string[] _sampleInput = @"199
200
208
210
200
207
240
269
260
263".Split(Environment.NewLine).ToArray();

    private Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(7);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(5);
}