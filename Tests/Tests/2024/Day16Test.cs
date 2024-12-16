using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day16Test
{
    private readonly string[] _sampleInput1 = @"###############
#.......#....E#
#.#.###.#.###.#
#.....#.#...#.#
#.###.#####.#.#
#.#.#.......#.#
#.#.#####.###.#
#...........#.#
###.#.#####.#.#
#...#.....#.#.#
#.#.#.###.#.#.#
#.....#...#.#.#
#.###.#.#.#.#.#
#S..#.....#...#
###############".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"#################
#...#...#...#..E#
#.#.#.#.#.#.#.#.#
#.#.#.#...#...#.#
#.#.#.#.###.#.#.#
#...#.#.#.....#.#
#.#.#.#.#.#####.#
#.#...#.#.#.....#
#.#.#####.#.###.#
#.#.#.......#...#
#.#.###.#####.###
#.#.#...#.....#.#
#.#.#.#####.###.#
#.#.#.........#.#
#.#.#.#########.#
#S#.............#
#################".Split(Environment.NewLine).ToArray();

    private Day16 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(7036);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(11048);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(45);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(64);
}