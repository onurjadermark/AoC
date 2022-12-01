using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day07Test
{
    private readonly string _sampleInput = @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";

    private readonly string _sampleInput2 = @"Step A must be finished before step B can begin.
Step B must be finished before step C can begin.
Step C must be finished before step D can begin.
Step D must be finished before step E can begin.
Step E must be finished before step F can begin.
Step F must be finished before step G can begin.
Step G must be finished before step H can begin.";

    private readonly string _sampleInput3 = @"Step A must be finished before step B can begin.
Step B must be finished before step C can begin.
Step C must be finished before step D can begin.
Step D must be finished before step E can begin.
Step A must be finished before step F can begin.
Step F must be finished before step G can begin.
Step G must be finished before step H can begin.";

    private readonly string _sampleInput4 = @"Step A must be finished before step B can begin.
Step A must be finished before step C can begin.
Step A must be finished before step D can begin.
Step A must be finished before step E can begin.
Step A must be finished before step F can begin.
Step A must be finished before step G can begin.
Step A must be finished before step H can begin.";

    public Day07 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput.Split('\n')).Should().Be("CABDFE");

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput.Split('\n')).Should().Be(15);

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2.Split('\n')).Should().Be(36);

    [Test]
    public void Part2C() => GetInstance().Part2(_sampleInput3.Split('\n')).Should().Be(22);

    [Test]
    public void Part2D() => GetInstance().Part2(_sampleInput4.Split('\n')).Should().Be(21);
}