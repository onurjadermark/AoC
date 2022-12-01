using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day09Test
{
    private readonly string _sampleInput = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

    private Day09 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput.Split('\n')).Should().Be(127);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput.Split('\n')).Should().Be(62);
}