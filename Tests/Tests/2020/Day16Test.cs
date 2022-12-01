using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day16Test
{
    private readonly string _sampleInput1 = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

    private readonly string _sampleInput2 = @"class: 1-3 or 5-7
row: 6-11 or 33-44
departure: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

    private Day16 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(71);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(14);
}