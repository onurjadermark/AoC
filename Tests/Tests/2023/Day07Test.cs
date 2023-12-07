using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day07Test
{
    private readonly string[] _sampleInput = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483".Split(Environment.NewLine).ToArray();

    private Day07 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(6440);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(5905);
}