using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class Day21Test
{
    private readonly string[] _sampleInput = @"root: pppw + sjmn
dbpl: 5
cczh: sllz + lgvd
zczc: 2
ptdq: humn - dvpt
dvpt: 3
lfqf: 4
humn: 5
ljgn: 2
sjmn: drzm * dbpl
sllz: 4
pppw: cczh / lfqf
lgvd: ljgn * ptdq
drzm: hmdt - zczc
hmdt: 32".Split(Environment.NewLine).ToArray();

    private Day21 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(152);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(301);
}