using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day03Test
{
    private readonly string[] _sampleInput1 =
    {
        "#1 @ 1,3: 4x4",
        "#2 @ 3,1: 4x4",
        "#3 @ 5,5: 2x2"
    };

    private readonly string[] _sampleInput2 =
    {
        "#1 @ 1,1: 7x1",
        "#2 @ 2,0: 3x3",
        "#3 @ 9,9: 2x2"
    };

    public Day03 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(4);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(3);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(3);
}