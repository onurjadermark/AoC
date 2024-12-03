using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day03Test
{
    private readonly string[] _sampleInput1 = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))".Split(Environment.NewLine).ToArray();

    private Day03 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(161);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput2).Should().Be(48);
}