using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day14Test
{
    public Day14 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1("9").Should().Be("5158916779");

    [Test]
    public void Part1B() => GetInstance().Part1("5").Should().Be("0124515891");

    [Test]
    public void Part1C() => GetInstance().Part1("18").Should().Be("9251071085");

    [Test]
    public void Part1D() => GetInstance().Part1("2018").Should().Be("5941429882");

    [Test]
    public void Part2A() => GetInstance().Part2("51589").Should().Be("9");

    [Test]
    public void Part2B() => GetInstance().Part2("01245").Should().Be("5");

    [Test]
    public void Part2C() => GetInstance().Part2("92510").Should().Be("18");

    [Test]
    public void Part2D() => GetInstance().Part2("59414").Should().Be("2018");
}