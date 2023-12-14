using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day14Test
{
    private readonly string[] _sampleInput = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....".Split(Environment.NewLine).ToArray();

    private Day14 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(136);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(64);
}