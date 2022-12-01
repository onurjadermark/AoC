using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day11Test
{
    private readonly string[] _sampleInput = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526".Split(Environment.NewLine).ToArray();

    private Day11 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(1656);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(195);
}