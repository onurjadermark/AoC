using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day13Test
{
    private readonly string _sampleInput1 = @"939
7,13,x,x,59,x,31,19";

    private readonly string _sampleInput2 = @"
17,x,13,19";

    private readonly string _sampleInput3 = @"
67,7,59,61";

    private readonly string _sampleInput4 = @"
67,x,7,59,61";

    private readonly string _sampleInput5 = @"
67,7,x,59,61";

    private readonly string _sampleInput6 = @"
1789,37,47,1889";

    private Day13 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(295);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(1068781);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(3417);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(754018);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput4.Split('\n')).Should().Be(779210);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput5.Split('\n')).Should().Be(1261476);

    [Test]
    public void Part2F() => GetInstance().Part2(_sampleInput6.Split('\n')).Should().Be(1202161486);
}