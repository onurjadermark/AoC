using System;
using FluentAssertions;
using NUnit.Framework;
using Solutions.Infrastructure;
using Solutions.Solutions._2024;

namespace Tests.Tests._2024;

[TestFixture]
public class RegressionTest
{
    private const int Year = 2024;
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
    public void Day01Part1() => new Day01().Part1(_day01Input.Value).Should().Be(2430334);

    [Test]
    public void Day01Part2() => new Day01().Part2(_day01Input.Value).Should().Be(28786472);

    [Test]
    public void Day02Part1() => new Day02().Part1(_day02Input.Value).Should().Be(371);

    [Test]
    public void Day02Part2() => new Day02().Part2(_day02Input.Value).Should().Be(413);

    [Test]
    public void Day03Part1() => new Day03().Part1(_day03Input.Value).Should().Be(170068701);

    [Test]
    public void Day03Part2() => new Day03().Part2(_day03Input.Value).Should().Be(78683433);

    [Test]
    public void Day04Part1() => new Day04().Part1(_day04Input.Value).Should().Be(2545);

    [Test]
    public void Day04Part2() => new Day04().Part2(_day04Input.Value).Should().Be(1886);

    [Test]
    public void Day05Part1() => new Day05().Part1(_day05Input.Value).Should().Be(0);

    [Test]
    public void Day05Part2() => new Day05().Part2(_day05Input.Value).Should().Be(0);

    [Test]
    public void Day06Part1() => new Day06().Part1(_day06Input.Value).Should().Be(0);

    [Test]
    public void Day06Part2() => new Day06().Part2(_day06Input.Value).Should().Be(0);

    [Test]
    public void Day07Part1() => new Day07().Part1(_day07Input.Value).Should().Be(0);

    [Test]
    public void Day07Part2() => new Day07().Part2(_day07Input.Value).Should().Be(0);

    [Test]
    public void Day08Part1() => new Day08().Part1(_day08Input.Value).Should().Be(0);

    [Test]
    public void Day08Part2() => new Day08().Part2(_day08Input.Value).Should().Be(0);

    [Test]
    public void Day09Part1() => new Day09().Part1(_day09Input.Value).Should().Be(0);

    [Test]
    public void Day09Part2() => new Day09().Part2(_day09Input.Value).Should().Be(0);

    [Test]
    public void Day10Part1() => new Day10().Part1(_day10Input.Value).Should().Be(0);

    [Test]
    public void Day10Part2() => new Day10().Part2(_day10Input.Value).Should().Be(0);

    [Test]
    public void Day11Part1() => new Day11().Part1(_day11Input.Value).Should().Be(0);

    [Test]
    public void Day11Part2() => new Day11().Part2(_day11Input.Value).Should().Be(0);

    [Test]
    public void Day12Part1() => new Day12().Part1(_day12Input.Value).Should().Be(0);

    [Test]
    public void Day12Part2() => new Day12().Part2(_day12Input.Value).Should().Be(0);

    [Test]
    public void Day13Part1() => new Day13().Part1(_day13Input.Value).Should().Be(0);

    [Test]
    public void Day13Part2() => new Day13().Part2(_day13Input.Value).Should().Be(0);

    [Test]
    public void Day14Part1() => new Day14().Part1(_day14Input.Value).Should().Be(0);

    [Test]
    public void Day14Part2() => new Day14().Part2(_day14Input.Value).Should().Be(0);

    [Test]
    public void Day15Part1() => new Day15().Part1(_day15Input.Value).Should().Be(0);

    [Test]
    public void Day15Part2() => new Day15().Part2(_day15Input.Value).Should().Be(0);

    [Test]
    public void Day16Part1() => new Day16().Part1(_day16Input.Value).Should().Be(0);

    [Test]
    public void Day16Part2() => new Day16().Part2(_day16Input.Value).Should().Be(0);

    [Test]
    public void Day17Part1() => new Day17().Part1(_day17Input.Value).Should().Be(0);

    [Test]
    public void Day17Part2() => new Day17().Part2(_day17Input.Value).Should().Be(0);

    [Test]
    public void Day18Part1() => new Day18().Part1(_day18Input.Value).Should().Be(0);

    [Test]
    public void Day18Part2() => new Day18().Part2(_day18Input.Value).Should().Be(0);

    [Test]
    public void Day19Part1() => new Day19().Part1(_day19Input.Value).Should().Be(0);

    [Test]
    public void Day19Part2() => new Day19().Part2(_day19Input.Value).Should().Be(0);

    [Test]
    public void Day20Part1() => new Day20().Part1(_day20Input.Value).Should().Be(0);

    [Test]
    public void Day20Part2() => new Day20().Part2(_day20Input.Value).Should().Be(0);

    [Test]
    public void Day21Part1() => new Day21().Part1(_day21Input.Value).Should().Be(0);

    [Test]
    public void Day21Part2() => new Day21().Part2(_day21Input.Value).Should().Be(0);

    [Test]
    public void Day22Part1() => new Day22().Part1(_day22Input.Value).Should().Be(0);

    [Test]
    public void Day22Part2() => new Day22().Part2(_day22Input.Value).Should().Be(0);

    [Test]
    public void Day23Part1() => new Day23().Part1(_day23Input.Value).Should().Be(0);

    [Test]
    public void Day23Part2() => new Day23().Part2(_day23Input.Value).Should().Be(0);

    [Test]
    public void Day24Part1() => new Day24().Part1(_day24Input.Value).Should().Be(0);

    [Test]
    public void Day24Part2() => new Day24().Part2(_day24Input.Value).Should().Be(0);

    [Test]
    public void Day25Part1() => new Day25().Part1(_day25Input.Value).Should().Be(0);
}