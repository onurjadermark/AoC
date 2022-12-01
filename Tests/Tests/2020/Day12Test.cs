using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day12Test
{
    private readonly string _sampleInput1 = @"F10
N3
F7
R90
F11";

    private readonly string _sampleInput2 = @"F10
R90
R90
L180
N100
E20
S100
L180
R90
R90
N3
N100
E100
W100
S100
F7
R90
R90
R90
R90
R90
L180
L180
L270
R270
F11";

    private readonly string _sampleInput3 = @"F1";

    private readonly string _sampleInput4 = @"N1
F1
R90
F1";

    private readonly string _sampleInput5 = @"S9
F1
R90
F1";

    private readonly string _sampleInput6 = @"S4
F1
R90
F1";

    private Day12 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(25);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2.Split('\n')).Should().Be(45);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(286);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(11);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput4.Split('\n')).Should().Be(20);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput5.Split('\n')).Should().Be(20);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput6.Split('\n')).Should().Be(20);
}