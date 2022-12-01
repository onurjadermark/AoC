using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day04Test
{
    private readonly string _sampleInput =
        @"[1518-11-01 00:00] Guard #10 begins shift
[1518 - 11 - 01 00:05] falls asleep
[1518 - 11 - 01 00:25] wakes up
[1518 - 11 - 01 00:30] falls asleep
[1518 - 11 - 01 00:55] wakes up
[1518 - 11 - 01 23:58] Guard #99 begins shift
[1518 - 11 - 02 00:40] falls asleep
[1518 - 11 - 02 00:50] wakes up
[1518 - 11 - 03 00:05] Guard #10 begins shift
[1518 - 11 - 03 00:24] falls asleep
[1518 - 11 - 03 00:29] wakes up
[1518 - 11 - 04 00:02] Guard #99 begins shift
[1518 - 11 - 04 00:36] falls asleep
[1518 - 11 - 04 00:46] wakes up
[1518 - 11 - 05 00:03] Guard #99 begins shift
[1518 - 11 - 05 00:45] falls asleep
[1518 - 11 - 05 00:55] wakes up}";

    public Day04 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput.Split('\n')).Should().Be(240);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput.Split('\n')).Should().Be(4455);
}