using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day09Test
{
    private const string SampleInput1 = @"9 players; last marble is worth 27 points";
    private const string SampleInput2 = @"10 players; last marble is worth 1618 points";
    private const string SampleInput3 = @"13 players; last marble is worth 7999 points";
    private const string SampleInput4 = @"17 players; last marble is worth 1104 points";
    private const string SampleInput5 = @"21 players; last marble is worth 6111 points";
    private const string SampleInput6 = @"30 players; last marble is worth 5807 points";

    public Day09 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(SampleInput1).Should().Be(32);

    [Test]
    public void Part1B() => GetInstance().Part1(SampleInput2).Should().Be(8317);

    [Test]
    public void Part1C() => GetInstance().Part1(SampleInput3).Should().Be(146373);

    [Test]
    public void Part1D() => GetInstance().Part1(SampleInput4).Should().Be(2764);

    [Test]
    public void Part1E() => GetInstance().Part1(SampleInput5).Should().Be(54718);

    [Test]
    public void Part1F() => GetInstance().Part1(SampleInput6).Should().Be(37305);
}