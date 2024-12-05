using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class Day05Test
{
    private readonly string[] _sampleInput1 = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47".Split(Environment.NewLine).ToArray();

    private Day05 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(143);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput1).Should().Be(123);
}