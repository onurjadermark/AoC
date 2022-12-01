using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day11Test
{
    private const string SampleInput1 = @"18";
    private const string SampleInput2 = @"42";

    public Day11 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(SampleInput1).Should().Be("33,45");

    [Test]
    public void Part1B() => GetInstance().Part1(SampleInput2).Should().Be("21,61");

    [Test]
    public void Part2A() => GetInstance().Part2(SampleInput1).Should().Be("90,269,16");

    [Test]
    public void Part2B() => GetInstance().Part2(SampleInput2).Should().Be("232,251,12");

    [Test]
    public void CalculateFuelPower1() => GetInstance().CalculateFuelCellPower(3, 5, 8).Should().Be(4);

    [Test]
    public void CalculateFuelPower2() => GetInstance().CalculateFuelCellPower(122, 79, 57).Should().Be(-5);

    [Test]
    public void CalculateFuelPower3() => GetInstance().CalculateFuelCellPower(217, 196, 39).Should().Be(0);

    [Test]
    public void CalculateFuelPower4() => GetInstance().CalculateFuelCellPower(101, 153, 71).Should().Be(4);
}