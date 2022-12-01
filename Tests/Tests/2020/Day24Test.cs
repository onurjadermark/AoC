using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2020;

namespace Tests.Tests._2020;

[TestFixture]
public class Day24Test
{
    private readonly string _sampleInput1 = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";

    private readonly string _sampleInput2 = @"nwwswee
nwwswee";

    private readonly string _sampleInput3 = @"nwwswee
nwwswee
nwwswee";

    private readonly string _sampleInput4 = @"";

    private Day24 GetInstance() => new();

    [Test]
    public void Part1A() => GetInstance().Part1(_sampleInput1.Split('\n')).Should().Be(10);

    [Test]
    public void Part1B() => GetInstance().Part1(_sampleInput2.Split('\n')).Should().Be(0);

    [Test]
    public void Part1C() => GetInstance().Part1(_sampleInput3.Split('\n')).Should().Be(1);

    [Test]
    public void Part1D() => GetInstance().Part1(_sampleInput4.Split('\n')).Should().Be(1);

    [Test]
    public void Part2A() => GetInstance().Part2(_sampleInput1.Split('\n')).Should().Be(2208);
}