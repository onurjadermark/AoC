using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day04Test
{
    private readonly string[] _sampleInput1 = @"..X...
.SAMX.
.A..A.
XMAS.S
.X....
......".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX".Split(Environment.NewLine).ToArray();

    private Day04 GetInstance() => new();
    
    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(4);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(18);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput2).Should().Be(9);
}