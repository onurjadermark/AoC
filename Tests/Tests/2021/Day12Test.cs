using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day12Test
{
    private readonly string[] _sampleInput1 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInput2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInput3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW".Split(Environment.NewLine).ToArray();

    private Day12 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1).Should().Be(10);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2).Should().Be(19);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3).Should().Be(226);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1).Should().Be(36);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2).Should().Be(103);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3).Should().Be(3509);
}