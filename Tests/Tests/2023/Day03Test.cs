using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day03Test
{
    private readonly string[] _sampleInput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..".Split(Environment.NewLine).ToArray();

    private Day03 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(4361);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(467835);
}