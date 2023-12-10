using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day10Test
{
    private readonly string[] _sampleInput1 = @".....
.S-7.
.|.|.
.L-J.
.....".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"..F7.
.FJ|.
SJ.L7
|F--J
LJ...".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput3 = @"...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput4 = @"..........
.S------7.
.|F----7|.
.||....||.
.||....||.
.|L-7F-J|.
.|..||..|.
.L--JL--J.
..........".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput5 = @".F----7F7F7F7F-7....
.|F--7||||||||FJ....
.||.FJ||||||||L7....
FJL7L7LJLJ||LJ.L-7..
L--J.L7...LJS7F-7L7.
....F-J..F7FJ|L7L7L7
....L7.F7||L7|.L7L7|
.....|FJLJ|FJ|F7|.LJ
....FJL-7.||.||||...
....L---J.LJ.LJLJ...".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput6 = @"FF7FSF7F7F7F7F7F---7
L|LJ||||||||||||F--J
FL-7LJLJ||||||LJL-77
F--JF--7||LJLJ7F7FJ-
L---JF-JLJ.||-FJLJJ7
|F|F-JF---7F7-L7L|7|
|FFJF7L7F-JF7|JL---7
7-L-JL7||F7|L7F-7F7|
L.L7LFJ|||||FJL7||LJ
L7JLJL-JLJLJL--JLJ.L".Split(Environment.NewLine).ToArray();

    private Day10 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(4);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(8);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(1);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(1);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3).Should().Be(4);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput4).Should().Be(4);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput5).Should().Be(8);

    [Test]
    public void Part2F() => GetInstance().Part2(_sampleInput6).Should().Be(10);
}