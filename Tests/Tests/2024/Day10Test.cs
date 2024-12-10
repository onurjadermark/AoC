using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day10Test
{
    private readonly string[] _sampleInput1 = @"0123
1234
8765
9876".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput3 = @".....0.
..4321.
..5..2.
..6543.
..7..4.
..8765.
..9....".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput4 = @"..90..9
...1.98
...2..7
6543456
765.987
876....
987....".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput5 = @"012345
123456
234567
345678
4.6789
56789.".Split(Environment.NewLine).ToArray();

    private Day10 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(1);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(36);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput3).Should().Be(3);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput4).Should().Be(13);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput5).Should().Be(227);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput2).Should().Be(81);
}