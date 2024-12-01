using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day23Test
{
    private readonly string[] _sampleInputA = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputB = @"#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputC = @"#############
#...........#
###B#A#C#D###
  #A#B#C#D#
  #########".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputD = @"#############
#...........#
###B#A#C#D###
  #B#A#C#D#
  #########".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputE = @"#############
#...........#
###A#C#B#D###
  #A#B#C#D#
  #########".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInputF = @"#############
#...........#
###A#B#D#C###
  #A#B#C#D#
  #########".Split(Environment.NewLine).ToArray();

    private Day23 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInputA).Should().Be(12521);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInputB).Should().Be(0);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInputC).Should().Be(46);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInputD).Should().Be(114);

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInputE).Should().Be(460);

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInputF).Should().Be(4600);

    [Test]
    [Explicit]
    public void Part2A() => GetInstance().Part2(_sampleInputA).Should().Be(44169);
}