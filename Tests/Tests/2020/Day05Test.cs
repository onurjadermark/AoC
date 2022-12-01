using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day05Test
{
    private readonly string[][] _sampleInputs =
    {
        new[] {"FBFBBFFRLR"},
        new[] {"BFFFBBFRRR"},
        new[] {"FFFBBBFRRR"},
        new[] {"BBFFBBFRLL"}
    };

    private readonly string[] _sampleInput2 =
    {
        "FBFBBFFLRL",
        "FBFBBFFLLL"
    };

    private Day05 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInputs[0]).Should().Be(357);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInputs[1]).Should().Be(567);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInputs[2]).Should().Be(119);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInputs[3]).Should().Be(820);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput2).Should().Be(353);
}