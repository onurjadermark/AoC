using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day06Test
{
    private readonly string[] _sampleInput = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb".Split(Environment.NewLine).ToArray();

    private Day06 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(7);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(19);
}