using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day24Test
{
    private readonly string[] _sampleInput = @"#.######
#>>.<^<#
#.<..<<#
#>v.><>#
#<^v^^>#
######.#".Split(Environment.NewLine).ToArray();

    private Day24 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(18);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(54);
}