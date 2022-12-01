using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day21Test
{
    private readonly string[] _sampleInput = @"Player 1 starting position: 4
Player 2 starting position: 8".Split(Environment.NewLine).ToArray();

    private Day21 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(739785);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(444356092776315);
}