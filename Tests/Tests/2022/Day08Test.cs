using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day08Test
{
    private readonly string[] _sampleInput = @"30373
25512
65332
33549
35390".Split(Environment.NewLine).ToArray();

    private Day08 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(21);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(8);
}