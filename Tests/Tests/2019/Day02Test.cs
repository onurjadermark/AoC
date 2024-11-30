using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2019;

namespace Tests.Tests._2019;

[TestFixture]
public class Day02Test
{
    private readonly string[] _sampleInput = @"1,9,10,3,2,3,11,0,99,30,40,50,60,32,615335".Split(Environment.NewLine).ToArray();

    private Day02 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(3100);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(0);
}