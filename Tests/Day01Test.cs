using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class Day01Test
{
    private readonly string[] _sampleInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Split(Environment.NewLine).ToArray();

    private Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(24000);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(45000);
}