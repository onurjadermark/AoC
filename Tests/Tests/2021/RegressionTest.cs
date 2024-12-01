using System;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Infrastructure;
using Solutions.Solutions._2021;

namespace Tests.Tests._2021;

[TestFixture]
public class RegressionTest
{
    private const int Year = 2021;
    private readonly Lazy<string[]> _day01Input = new(() => new InputLoader(Year, 01).ReadLines<string>());
    private readonly Lazy<string[]> _day02Input = new(() => new InputLoader(Year, 02).ReadLines<string>());
    private readonly Lazy<string[]> _day03Input = new(() => new InputLoader(Year, 03).ReadLines<string>());
    private readonly Lazy<string[]> _day04Input = new(() => new InputLoader(Year, 04).ReadLines<string>());
    private readonly Lazy<string[]> _day05Input = new(() => new InputLoader(Year, 05).ReadLines<string>());
    private readonly Lazy<string[]> _day06Input = new(() => new InputLoader(Year, 06).ReadLines<string>());
    private readonly Lazy<string[]> _day07Input = new(() => new InputLoader(Year, 07).ReadLines<string>());
    private readonly Lazy<string[]> _day08Input = new(() => new InputLoader(Year, 08).ReadLines<string>());
    private readonly Lazy<string[]> _day09Input = new(() => new InputLoader(Year, 09).ReadLines<string>());
    private readonly Lazy<string[]> _day10Input = new(() => new InputLoader(Year, 10).ReadLines<string>());
    private readonly Lazy<string[]> _day11Input = new(() => new InputLoader(Year, 11).ReadLines<string>());
    private readonly Lazy<string[]> _day12Input = new(() => new InputLoader(Year, 12).ReadLines<string>());
    private readonly Lazy<string[]> _day13Input = new(() => new InputLoader(Year, 13).ReadLines<string>());
    private readonly Lazy<string[]> _day14Input = new(() => new InputLoader(Year, 14).ReadLines<string>());
    private readonly Lazy<string[]> _day15Input = new(() => new InputLoader(Year, 15).ReadLines<string>());
    private readonly Lazy<string[]> _day16Input = new(() => new InputLoader(Year, 16).ReadLines<string>());
    private readonly Lazy<string[]> _day17Input = new(() => new InputLoader(Year, 17).ReadLines<string>());
    private readonly Lazy<string[]> _day18Input = new(() => new InputLoader(Year, 18).ReadLines<string>());
    private readonly Lazy<string[]> _day19Input = new(() => new InputLoader(Year, 19).ReadLines<string>());
    private readonly Lazy<string[]> _day20Input = new(() => new InputLoader(Year, 20).ReadLines<string>());
    private readonly Lazy<string[]> _day21Input = new(() => new InputLoader(Year, 21).ReadLines<string>());
    private readonly Lazy<string[]> _day22Input = new(() => new InputLoader(Year, 22).ReadLines<string>());
    private readonly Lazy<string[]> _day23Input = new(() => new InputLoader(Year, 23).ReadLines<string>());
    private readonly Lazy<string[]> _day24Input = new(() => new InputLoader(Year, 24).ReadLines<string>());
    private readonly Lazy<string[]> _day25Input = new(() => new InputLoader(Year, 25).ReadLines<string>());

    [Test]
    public void Day01Part1() => new Day01().Part1(_day01Input.Value).Should().Be(1400);

    [Test]
    public void Day01Part2() => new Day01().Part2(_day01Input.Value).Should().Be(1429);

    [Test]
    public void Day02Part1() => new Day02().Part1(_day02Input.Value).Should().Be(1427868);

    [Test]
    public void Day02Part2() => new Day02().Part2(_day02Input.Value).Should().Be(1568138742);

    [Test]
    public void Day03Part1() => new Day03().Part1(_day03Input.Value).Should().Be(1025636);

    [Test]
    public void Day03Part2() => new Day03().Part2(_day03Input.Value).Should().Be(793873);

    [Test]
    public void Day04Part1() => new Day04().Part1(_day04Input.Value).Should().Be(50008);

    [Test]
    public void Day04Part2() => new Day04().Part2(_day04Input.Value).Should().Be(17408);

    [Test]
    public void Day05Part1() => new Day05().Part1(_day05Input.Value).Should().Be(7473);

    [Test]
    public void Day05Part2() => new Day05().Part2(_day05Input.Value).Should().Be(24164);

    [Test]
    public void Day06Part1() => new Day06().Part1(_day06Input.Value).Should().Be(390923);

    [Test]
    public void Day06Part2() => new Day06().Part2(_day06Input.Value).Should().Be(1749945484935);

    [Test]
    public void Day07Part1() => new Day07().Part1(_day07Input.Value).Should().Be(329389);

    [Test]
    public void Day07Part2() => new Day07().Part2(_day07Input.Value).Should().Be(86397080);

    [Test]
    public void Day08Part1() => new Day08().Part1(_day08Input.Value).Should().Be(294);

    [Test]
    public void Day08Part2() => new Day08().Part2(_day08Input.Value).Should().Be(973292);

    [Test]
    public void Day09Part1() => new Day09().Part1(_day09Input.Value).Should().Be(423);

    [Test]
    public void Day09Part2() => new Day09().Part2(_day09Input.Value).Should().Be(1198704);

    [Test]
    public void Day10Part1() => new Day10().Part1(_day10Input.Value).Should().Be(369105);

    [Test]
    public void Day10Part2() => new Day10().Part2(_day10Input.Value).Should().Be(3999363569);

    [Test]
    public void Day11Part1() => new Day11().Part1(_day11Input.Value).Should().Be(1601);

    [Test]
    public void Day11Part2() => new Day11().Part2(_day11Input.Value).Should().Be(368);

    [Test]
    public void Day12Part1() => new Day12().Part1(_day12Input.Value).Should().Be(3713);

    [Test]
    public void Day12Part2() => new Day12().Part2(_day12Input.Value).Should().Be(91292);

    [Test]
    public void Day13Part1() => new Day13().Part1(_day13Input.Value).Should().Be("810");

    [Test]
    public void Day13Part2() => new Day13().Part2(_day13Input.Value).Should().Be(Day13.Part2Answer);

    [Test]
    public void Day14Part1() => new Day14().Part1(_day14Input.Value).Should().Be(3555);

    [Test]
    public void Day14Part2() => new Day14().Part2(_day14Input.Value).Should().Be(4439442043739);

    [Test]
    public void Day15Part1() => new Day15().Part1(_day15Input.Value).Should().Be(398);

    [Test]
    public void Day15Part2() => new Day15().Part2(_day15Input.Value).Should().Be(2817);

    [Test]
    public void Day16Part1() => new Day16().Part1(_day16Input.Value).Should().Be(993);

    [Test]
    public void Day16Part2() => new Day16().Part2(_day16Input.Value).Should().Be(144595909277);

    [Test]
    public void Day17Part1() => new Day17().Part1(_day17Input.Value).Should().Be(5151);

    [Test]
    public void Day17Part2() => new Day17().Part2(_day17Input.Value).Should().Be(968);

    [Test]
    public void Day18Part1() => new Day18().Part1(_day18Input.Value).Should().Be(4088);

    [Test]
    public void Day18Part2() => new Day18().Part2(_day18Input.Value).Should().Be(4536);

    [Test]
    public void Day19Part1() => new Day19().Part1(_day19Input.Value).Should().Be(425);

    [Test]
    public void Day19Part2() => new Day19().Part2(_day19Input.Value).Should().Be(13354);

    [Test]
    public void Day20Part1() => new Day20().Part1(_day20Input.Value).Should().Be(5583);

    [Test]
    public void Day20Part2() => new Day20().Part2(_day20Input.Value).Should().Be(19592);

    [Test]
    public void Day21Part1() => new Day21().Part1(_day21Input.Value).Should().Be(734820);

    [Test]
    public void Day21Part2() => new Day21().Part2(_day21Input.Value).Should().Be(193170338541590);

    [Test]
    public void Day22Part1() => new Day22().Part1(_day22Input.Value).Should().Be(537042);

    [Test]
    public void Day22Part2() => new Day22().Part2(_day22Input.Value).Should().Be(1304385553084863);

    [Test]
    public void Day23Part1() => new Day23().Part1(_day23Input.Value).Should().Be(19160);

    [Test]
    [Explicit]
    public void Day23Part2() => new Day23().Part2(_day23Input.Value).Should().Be(47232);

    [Test]
    public void Day24Part1() => new Day24().Part1(_day24Input.Value).Should().Be(79197919993985);

    [Test]
    public void Day24Part2() => new Day24().Part2(_day24Input.Value).Should().Be(13191913571211);

    [Test]
    public void Day25Part1() => new Day25().Part1(_day25Input.Value).Should().Be(453);
}