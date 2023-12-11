using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day11Test
{
    private readonly string[] _sampleInput = @"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....".Split(Environment.NewLine).ToArray();

    private Day11 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(374);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(82000210);
}