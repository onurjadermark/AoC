using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day22Test
{
    private readonly string[] _sampleInput = @"        ...#
        .#..
        #...
        ....
...#.......#
........#...
..#....#....
..........#.
        ...#....
        .....#..
        .#......
        ......#.

10R5L5R10L4R5L5".Split(Environment.NewLine).ToArray();

    private Day22 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(6032);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(0);
}