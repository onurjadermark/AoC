using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day18Test
{
    private readonly string[] _sampleInputA = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputB = @"[[[[4,3],4],4],[7,[[8,4],9]]]
[1,1]".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputC = @"[[1,2],[[3,4],5]]".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInputD = @"[[[[0,7],4],[[7,8],[6,0]]],[8,1]]".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInputE = @"[[[[1,1],[2,2]],[3,3]],[4,4]]".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInputF = @"[[[[3,0],[5,3]],[4,4]],[5,5]]".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInputG = @"[[[[5,0],[7,4]],[5,5]],[6,6]]".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputH =
        @"[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputI = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]".Split(Environment.NewLine).ToArray();

    private Day18 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInputA).Should().Be(4140);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInputB).Should().Be(1384);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInputC).Should().Be(143);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInputD).Should().Be(1384);

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInputE).Should().Be(445);

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInputF).Should().Be(791);

    [Test]
    public void Part1G() => GetInstance().Part1(_sampleInputG).Should().Be(1137);

    [Test]
    public void Part1H() => GetInstance().Part1(_sampleInputH).Should().Be(3488);

    [Test]
    public void Part1I() => GetInstance().Part1(_sampleInputI).Should().Be(3488);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInputA).Should().Be(3993);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInputB).Should().Be(1384);
}