using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day01Test
{
    private readonly int[] _sampleInput1 =
    {
        -1,
        -2,
        -3
    };

    private readonly int[] _sampleInput2A = {1, -2};
    private readonly int[] _sampleInput2B = {3, 3, 4, -2, -4};
    private readonly int[] _sampleInput2C = {-6, 3, 8, 5, -6};
    private readonly int[] _sampleInput2D = {7, 7, -2, -7, -4};

    public Day01 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(-6);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput2A).Should().Be(0);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2B).Should().Be(10);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput2C).Should().Be(5);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput2D).Should().Be(14);
}