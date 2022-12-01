using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day02Test
{
    private readonly string[] _sampleInput1 =
    {
        "abcdef",
        "bababc",
        "abbcde",
        "abcccd",
        "aabcdd",
        "abcdee",
        "ababab"
    };

    private readonly string[] _sampleInput2A =
    {
        "abcde",
        "fghij",
        "klmno",
        "pqrst",
        "fguij",
        "axcye",
        "wvxyz"
    };

    private readonly string[] _sampleInput2B =
    {
        "pqrst",
        "gfuij",
        "hguiu",
        "axcye",
        "wvxyz",
        "abcde",
        "hghiu",
        "klmno"
    };

    public Day02 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(_sampleInput1).Should().Be(12);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput2A).Should().Be("fgij");

    [Test]
    public void Part2B() => GetInstance().Part2(_sampleInput2B).Should().Be("hgiu");
}