using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day08Test
{
    private readonly string[] _sampleInput1 = @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput3 = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)".Split(Environment.NewLine).ToArray();

    private Day08 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(2);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(6);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput3).Should().Be(6);
}