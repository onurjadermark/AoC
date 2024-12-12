using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day12Test
{
    private readonly string[] _sampleInput1 = @"AAAA
BBCD
BBCC
EEEC".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"OOOOO
OXOXO
OOOOO
OXOXO
OOOOO".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput3 = @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput4 = @"EEEEE
EXXXX
EEEEE
EXXXX
EEEEE".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput5 = @"AAAAAA
AAABBA
AAABBA
ABBAAA
ABBAAA
AAAAAA".Split(Environment.NewLine).ToArray();

    private Day12 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(140);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(772);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3).Should().Be(1930);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(80);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(436);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput4).Should().Be(236);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput5).Should().Be(368);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput3).Should().Be(1206);
}