using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day13Test
{
    private readonly string[] _sampleInput1 = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5".Split(Environment.NewLine).ToArray();

    private Day13 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be("17");

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(@"
#####
#...#
#...#
#...#
#####
.....
.....");
}