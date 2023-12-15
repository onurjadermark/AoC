using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day15Test
{
    private readonly string[] _sampleInput = @"rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7".Split(Environment.NewLine).ToArray();

    private Day15 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(1320);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(145);
}