using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class Day16Test
{
    private readonly string[] _sampleInput1A = @"D2FE28".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1B = @"38006F45291200".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1C = @"EE00D40C823060".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1D = @"8A004A801A8002F478".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1E = @"620080001611562C8802118E34".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1F = @"C0015000016115A2E0802F182340".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput1G = @"A0016C880162017C3686B18A3D4780".Split(Environment.NewLine).ToArray();

    private readonly string[] _sampleInput2A = @"C200B40A82".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2B = @"04005AC33890".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2C = @"880086C3E88112".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2D = @"CE00C43D881120".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2E = @"D8005AC2A8F0".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2F = @"F600BC2D8F".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2G = @"9C005AC2F8F0".Split(Environment.NewLine).ToArray();
    private readonly string[] _sampleInput2H = @"9C0141080250320F1802104A08".Split(Environment.NewLine).ToArray();

    private Day16 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1A).Should().Be(6);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput1B).Should().Be(9);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput1C).Should().Be(14);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInput1D).Should().Be(16);

    [Test]
    public void Part1E() => GetInstance().Part1(_sampleInput1E).Should().Be(12);

    [Test]
    public void Part1F() => GetInstance().Part1(_sampleInput1F).Should().Be(23);

    [Test]
    public void Part1G() => GetInstance().Part1(_sampleInput1G).Should().Be(31);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput2A).Should().Be(3);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2B).Should().Be(54);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput2C).Should().Be(7);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput2D).Should().Be(9);

    [Test]
    public void Part2E() => GetInstance().Part2(_sampleInput2E).Should().Be(1);

    [Test]
    public void Part2F() => GetInstance().Part2(_sampleInput2F).Should().Be(0);

    [Test]
    public void Part2G() => GetInstance().Part2(_sampleInput2G).Should().Be(0);

    [Test]
    public void Part2H() => GetInstance().Part2(_sampleInput2H).Should().Be(1);
}