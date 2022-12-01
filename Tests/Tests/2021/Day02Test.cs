using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day02Test
{
    private readonly string[] _sampleInput = @"forward 5
down 5
forward 8
up 3
down 8
forward 2".Split(Environment.NewLine).ToArray();

    private Day02 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(150);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(900);
}