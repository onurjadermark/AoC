using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day09Test
{
    private readonly string[] _sampleInput = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".Split(Environment.NewLine).ToArray();

    private Day09 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(13);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(1);
}