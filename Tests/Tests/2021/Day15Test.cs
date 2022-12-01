using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day15Test
{
    private readonly string[] _sampleInput1 = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581".Split(Environment.NewLine).ToArray();

    private Day15 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(40);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(315);
}