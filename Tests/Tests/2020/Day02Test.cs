using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day02Test
{
    private readonly string[] _sampleInput =
    {
        "1-3 a: abcde",
        "1-3 b: cdefg",
        "2-9 c: ccccccccc"
    };

    private Day02 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput).Should().Be(2);

    [Test]
    public void Part2() => GetInstance().Part2(_sampleInput).Should().Be(1);
}