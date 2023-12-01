using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day01Test
{
    private readonly string[] _sampleInput1 = @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen".Split(Environment.NewLine).ToArray();

    private Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(142);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput2).Should().Be(281);
}