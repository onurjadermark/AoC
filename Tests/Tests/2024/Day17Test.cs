using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day17Test
{
    private readonly string[] _sampleInput1 = @"Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"Register A: 0
Register B: 0
Register C: 9

Program: 2,6".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput3 = @"Register A: 10
Register B: 0
Register C: 0

Program: 5,0,5,1,5,4".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput4 = @"Register A: 2024
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput5 = @"Register A: 0
Register B: 29
Register C: 0

Program: 1,7".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput6 = @"Register A: 0
Register B: 2024
Register C: 43690

Program: 4,0".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput7 = @"Register A: 2024
Register B: 0
Register C: 0

Program: 0,3,5,4,3,0".Split(Environment.NewLine).ToArray();

    private Day17 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be("4,6,3,5,6,3,5,2,1,0");

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be("");

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3).Should().Be("0,1,2");

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInput4).Should().Be("4,2,5,6,7,7,7,7,3,1,0");

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInput5).Should().Be("");

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInput6).Should().Be("");

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput7).Should().Be("117440");
}