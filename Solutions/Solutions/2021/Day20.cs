using System.Text;

namespace Solutions.Solutions._2021;

public class Day20
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var size = input[2].Length;
        var algorithm = new string(input[0].Select(x => x == '.' ? '0' : '1').ToArray());
        var image = new string(string.Join("", input.Skip(2)).Select(x => x == '.' ? '0' : '1').ToArray());

        for (var t = 0; t < (part == 1 ? 2 : 50); t++)
        {
            var imageBuilder = new StringBuilder();
            for (var y = -1; y < size + 1; y++)
            for (var x = -1; x < size + 1; x++)
            {
                var subImageBuilder = new StringBuilder();
                for (var j = -1; j <= 1; j++)
                for (var i = -1; i <= 1; i++)
                    if (x + i < 0 || y + j < 0 || x + i >= size || y + j >= size)
                    {
                        switch (algorithm[0])
                        {
                            case '0':
                                subImageBuilder.Append("0");
                                break;
                            case '1' when algorithm[^1] == '0':
                                subImageBuilder.Append(t % 2 == 0 ? "0" : "1");
                                break;
                            default:
                                subImageBuilder.Append(t == 0 ? "0" : "1");
                                break;
                        }
                    }
                    else
                    {
                        var index = (y + j) * size + x + i;
                        var toAppend = image[index];
                        subImageBuilder.Append(toAppend);
                    }

                var subImage = subImageBuilder.ToString();
                var subImageCode = Convert.ToInt32(subImage, 2);
                var enhanced = algorithm[subImageCode];
                imageBuilder.Append(enhanced);
            }

            size += 2;
            image = imageBuilder.ToString();
        }

        return image.Count(x => x == '1');
    }
}