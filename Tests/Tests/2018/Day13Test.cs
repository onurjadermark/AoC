using FluentAssertions;
using NUnit.Framework;
using Solutions.Solutions._2018;

namespace Tests.Tests._2018;

[TestFixture]
public class Day13Test
{
    private const string SampleInput1 = @"/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   ";

    private const string SampleInput2 = @"/>-<\  
|   |  
| /<+-\
| | | v
\>+</ |
  |   ^
  \<->/";

    public Day13 GetInstance() => new();

    [Test]
    public void Part1() => GetInstance().Part1(SampleInput1).Should().Be("7,3");

    [Test]
    public void Part2() => GetInstance().Part2(SampleInput2).Should().Be("6,4");
}