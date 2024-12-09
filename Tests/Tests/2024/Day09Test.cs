using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day09Test
{
    private readonly string[] _sampleInput1 = @"2333133121414131402".Split(Environment.NewLine).ToArray();

    private Day09 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(1928);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(2858);
}