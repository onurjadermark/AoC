using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day15Test
{
    private readonly string _sampleInput1 = @"0,3,6";
    private readonly string _sampleInput2 = @"1,3,2";
    private readonly string _sampleInput3 = @"2,1,3";
    private readonly string _sampleInput4 = @"1,2,3";
    private readonly string _sampleInput5 = @"2,3,1";
    private readonly string _sampleInput6 = @"3,2,1";
    private readonly string _sampleInput7 = @"3,1,2";

    private Day15 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(436);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2.Split('\n')).Should().Be(1);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3.Split('\n')).Should().Be(10);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInput4.Split('\n')).Should().Be(27);

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInput5.Split('\n')).Should().Be(78);

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInput6.Split('\n')).Should().Be(438);

    [Test]
    public void Part1G() => GetInstance().Part1(_sampleInput7.Split('\n')).Should().Be(1836);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(175594);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(2578);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(3544142);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput4.Split('\n')).Should().Be(261214);
}