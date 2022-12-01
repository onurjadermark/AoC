using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day05Test
{
    private readonly string _sampleInput = "dabAcCaCBAcCcaDA";
    private readonly string _sampleInput2 = "dabAcCaCBAcCcaDAbBcDeFfEdCx";
    private readonly string _sampleInput3 = "aAbB";

    public Day05 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput).Should().Be(10);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(11);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3).Should().Be(0);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(4);
}