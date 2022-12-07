using FluentAssertions;
using NUnit.Framework;
using Solutions.Infrastructure;
using Solutions.Solutions._2022;

namespace Tests.Tests._2022;

[TestFixture]
public class RegressionTest
{
    private const int Year = 2022;
    private readonly string[] _day01Input = new InputLoader(Year, 01).ReadLines<string>();
    private readonly string[] _day02Input = new InputLoader(Year, 02).ReadLines<string>();
    private readonly string[] _day03Input = new InputLoader(Year, 03).ReadLines<string>();
    private readonly string[] _day04Input = new InputLoader(Year, 04).ReadLines<string>();
    private readonly string[] _day05Input = new InputLoader(Year, 05).ReadLines<string>();
    private readonly string[] _day06Input = new InputLoader(Year, 06).ReadLines<string>();
    private readonly string[] _day07Input = new InputLoader(Year, 07).ReadLines<string>();
    private readonly string[] _day08Input = new InputLoader(Year, 08).ReadLines<string>();
    private readonly string[] _day09Input = new InputLoader(Year, 09).ReadLines<string>();
    private readonly string[] _day10Input = new InputLoader(Year, 10).ReadLines<string>();
    private readonly string[] _day11Input = new InputLoader(Year, 11).ReadLines<string>();
    private readonly string[] _day12Input = new InputLoader(Year, 12).ReadLines<string>();
    private readonly string[] _day13Input = new InputLoader(Year, 13).ReadLines<string>();
    private readonly string[] _day14Input = new InputLoader(Year, 14).ReadLines<string>();
    private readonly string[] _day15Input = new InputLoader(Year, 15).ReadLines<string>();
    private readonly string[] _day16Input = new InputLoader(Year, 16).ReadLines<string>();
    private readonly string[] _day17Input = new InputLoader(Year, 17).ReadLines<string>();
    private readonly string[] _day18Input = new InputLoader(Year, 18).ReadLines<string>();
    private readonly string[] _day19Input = new InputLoader(Year, 19).ReadLines<string>();
    private readonly string[] _day20Input = new InputLoader(Year, 20).ReadLines<string>();
    private readonly string[] _day21Input = new InputLoader(Year, 21).ReadLines<string>();
    private readonly string[] _day22Input = new InputLoader(Year, 22).ReadLines<string>();
    private readonly string[] _day23Input = new InputLoader(Year, 23).ReadLines<string>();
    private readonly string[] _day24Input = new InputLoader(Year, 24).ReadLines<string>();
    private readonly string[] _day25Input = new InputLoader(Year, 25).ReadLines<string>();

    [Test]
    public void Day01Part1() => new Day01().Part1(_day01Input).Should().Be(68467);

    [Test]
    public void Day01Part2() => new Day01().Part2(_day01Input).Should().Be(203420);

    [Test]
    public void Day02Part1() => new Day02().Part1(_day02Input).Should().Be(15572);

    [Test]
    public void Day02Part2() => new Day02().Part2(_day02Input).Should().Be(16098);

    [Test]
    public void Day03Part1() => new Day03().Part1(_day03Input).Should().Be(7831);

    [Test]
    public void Day03Part2() => new Day03().Part2(_day03Input).Should().Be(2683);

    [Test]
    public void Day04Part1() => new Day04().Part1(_day04Input).Should().Be(515);

    [Test]
    public void Day04Part2() => new Day04().Part2(_day04Input).Should().Be(883);

    [Test]
    public void Day05Part1() => new Day05().Part1(_day05Input).Should().Be("QNHWJVJZW");

    [Test]
    public void Day05Part2() => new Day05().Part2(_day05Input).Should().Be("BPCZJLFJW");

    [Test]
    public void Day06Part1() => new Day06().Part1(_day06Input).Should().Be(1848);

    [Test]
    public void Day06Part2() => new Day06().Part2(_day06Input).Should().Be(2308);

    [Test]
    public void Day07Part1() => new Day07().Part1(_day07Input).Should().Be(1844187);

    [Test]
    public void Day07Part2() => new Day07().Part2(_day07Input).Should().Be(4978279);

    [Test]
    public void Day08Part1() => new Day08().Part1(_day08Input).Should().Be(0);

    [Test]
    public void Day08Part2() => new Day08().Part2(_day08Input).Should().Be(0);

    [Test]
    public void Day09Part1() => new Day09().Part1(_day09Input).Should().Be(0);

    [Test]
    public void Day09Part2() => new Day09().Part2(_day09Input).Should().Be(0);

    [Test]
    public void Day10Part1() => new Day10().Part1(_day10Input).Should().Be(0);

    [Test]
    public void Day10Part2() => new Day10().Part2(_day10Input).Should().Be(0);

    [Test]
    public void Day11Part1() => new Day11().Part1(_day11Input).Should().Be(0);

    [Test]
    public void Day11Part2() => new Day11().Part2(_day11Input).Should().Be(0);

    [Test]
    public void Day12Part1() => new Day12().Part1(_day12Input).Should().Be(0);

    [Test]
    public void Day12Part2() => new Day12().Part2(_day12Input).Should().Be(0);

    [Test]
    public void Day13Part1() => new Day13().Part1(_day13Input).Should().Be(0);

    [Test]
    public void Day13Part2() => new Day13().Part2(_day13Input).Should().Be(0);

    [Test]
    public void Day14Part1() => new Day14().Part1(_day14Input).Should().Be(0);

    [Test]
    public void Day14Part2() => new Day14().Part2(_day14Input).Should().Be(0);

    [Test]
    public void Day15Part1() => new Day15().Part1(_day15Input).Should().Be(0);

    [Test]
    public void Day15Part2() => new Day15().Part2(_day15Input).Should().Be(0);

    [Test]
    public void Day16Part1() => new Day16().Part1(_day16Input).Should().Be(0);

    [Test]
    public void Day16Part2() => new Day16().Part2(_day16Input).Should().Be(0);

    [Test]
    public void Day17Part1() => new Day17().Part1(_day17Input).Should().Be(0);

    [Test]
    public void Day17Part2() => new Day17().Part2(_day17Input).Should().Be(0);

    [Test]
    public void Day18Part1() => new Day18().Part1(_day18Input).Should().Be(0);

    [Test]
    public void Day18Part2() => new Day18().Part2(_day18Input).Should().Be(0);

    [Test]
    public void Day19Part1() => new Day19().Part1(_day19Input).Should().Be(0);

    [Test]
    public void Day19Part2() => new Day19().Part2(_day19Input).Should().Be(0);

    [Test]
    public void Day20Part1() => new Day20().Part1(_day20Input).Should().Be(0);

    [Test]
    public void Day20Part2() => new Day20().Part2(_day20Input).Should().Be(0);

    [Test]
    public void Day21Part1() => new Day21().Part1(_day21Input).Should().Be(0);

    [Test]
    public void Day21Part2() => new Day21().Part2(_day21Input).Should().Be(0);

    [Test]
    public void Day22Part1() => new Day22().Part1(_day22Input).Should().Be(0);

    [Test]
    public void Day22Part2() => new Day22().Part2(_day22Input).Should().Be(0);

    [Test]
    public void Day23Part1() => new Day23().Part1(_day23Input).Should().Be(0);

    [Test]
    public void Day23Part2() => new Day23().Part2(_day23Input).Should().Be(0);

    [Test]
    public void Day24Part1() => new Day24().Part1(_day24Input).Should().Be(0);

    [Test]
    public void Day24Part2() => new Day24().Part2(_day24Input).Should().Be(0);

    [Test]
    public void Day25Part1() => new Day25().Part1(_day25Input).Should().Be(0);
}