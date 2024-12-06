using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day06Test
{
    private readonly string[] _sampleInput1 = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...".Split(Environment.NewLine).ToArray();

    private Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(41);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(6);
}