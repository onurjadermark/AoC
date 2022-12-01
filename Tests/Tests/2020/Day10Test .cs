using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day10Test
{
    private readonly string _sampleInput1 = @"16
10
15
5
1
11
7
19
6
12
4";

    private readonly string _sampleInput2 = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

    private readonly string _sampleInput3 = @"3
5
7
9";

    private Day10 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(35);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2.Split('\n')).Should().Be(220);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(8);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(19208);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(1);
}