using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2023;

namespace Tests.Tests._2023;

[TestFixture]
public class Day20Test
{
    private readonly string[] _sampleInput1 = @"broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a".Split(Environment.NewLine).ToArray();
    
    private readonly string[] _sampleInput2 = @"broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output".Split(Environment.NewLine).ToArray();

    private Day20 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(32000000);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(11687500);
}