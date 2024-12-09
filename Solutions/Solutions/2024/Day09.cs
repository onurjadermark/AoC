﻿namespace Solutions.Solutions._2024;

public class Day09
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
        var inputLine = input[0].Select(x => x - '0').ToArray();
        
        var disk = new string[inputLine.Sum()];
        var sizes = new Dictionary<int, int>();
        var locations = new Dictionary<int, int>();
        var emptyIndices = new List<int>();
        
        var isFile = true;
        var id = 0;
        var cur = 0;

        foreach (var size in inputLine)
        {
            sizes[id] = size;
            locations[id] = cur;
            
            for (var i = 0; i < size; i++)
            {
                if (!isFile) emptyIndices.Add(cur);
                disk[cur++] = isFile ? id.ToString() : ".";
            }
            
            if (isFile) id++;
            isFile = !isFile;
        }

        if (part == 1)
        {
            for (var i = disk.Length - 1; i >= 0; i--)
            {
                if (disk[i] == ".") continue;
                if (emptyIndices.First() >= i) continue;
                var emptyIndex = emptyIndices.First();
                disk[emptyIndex] = disk[i];
                disk[i] = ".";
                emptyIndices.RemoveAt(0);
            }
        }
        else
        {
            for (var i = id - 1; i >= 0; i--)
            {
                var location = locations[i];
                var size = sizes[i];
                
                for (var j = 0; j < location; j++)
                {
                    if (disk[j] != ".") continue;

                    var emptySize = 0;
                    for (var k = j; k < disk.Length; k++)
                    {
                        if (disk[k] == ".")
                        {
                            emptySize++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (emptySize < size) continue;
                    
                    for (var k = 0; k < size; k++)
                    {
                        disk[j + k] = i.ToString();
                    }
                    
                    for (var k = 0; k < size; k++)
                    {
                        disk[location + k] = ".";
                    }
                    
                    break;
                }
            }
        }

        return disk.Select((x, i) => x == "." ? 0 : long.Parse(x) * i).Sum();
    }
}