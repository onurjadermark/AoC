using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2019;

namespace Tests.Tests._2019;

[TestFixture]
public class Day01Test
{
    private readonly string[] _sampleInput = @"100756".Split(Environment.NewLine).ToArray();

    private Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(33583);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(50346);
}