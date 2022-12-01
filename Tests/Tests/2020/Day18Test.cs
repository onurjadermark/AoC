using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day18Test
{
    private readonly string _sampleInput0 = @"5 * 10 + (1 * 2 * 1)";
    private readonly string _sampleInput1 = @"1 + 2 * 3 + 4 * 5 + 6";
    private readonly string _sampleInput2 = @"2 * 3 + (4 * 5)";
    private readonly string _sampleInput3 = @"5 + (8 * 3 + 9 + 3 * 4 * 3)";
    private readonly string _sampleInput4 = @"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))";
    private readonly string _sampleInput5 = @"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

    private Day18 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(71);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2.Split('\n')).Should().Be(26);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3.Split('\n')).Should().Be(437);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInput4.Split('\n')).Should().Be(12240);

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInput5.Split('\n')).Should().Be(13632);

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInput0.Split('\n')).Should().Be(52);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(231);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(46);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(1445);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput4.Split('\n')).Should().Be(669060);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput5.Split('\n')).Should().Be(23340);

    [Test]
    public void Part2F() => GetInstance().Part2(_sampleInput0.Split('\n')).Should().Be(60);
}