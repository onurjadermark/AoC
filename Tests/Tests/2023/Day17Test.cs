using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day17Test
{
    private readonly string[] _sampleInput1 = @"2413432311323
3215453535623
3255245654254
3446585845452
4546657867536
1438598798454
4457876987766
3637877979653
4654967986887
4564679986453
1224686865563
2546548887735
4322674655533".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"111111111111
999999999991
999999999991
999999999991
999999999991".Split(Environment.NewLine).ToArray();

    private Day17 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(102);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(94);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(71);
}