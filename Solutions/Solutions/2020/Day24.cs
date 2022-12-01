namespace Solutions.Solutions._2020;

public class Day24
{
    private static readonly List<(int X, int Y)> Neighbours = new()
    {
        (2, 0),
        (-2, 0),
        (1, 1),
        (1, -1),
        (-1, 1),
        (-1, -1)
    };

    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var tiles = new Dictionary<string, int>();
        foreach (var line in input.Select(x => x.Trim()))
        {
            var x = 0;
            var y = 0;
            for (var i = 0; i < line.Length; i++)
            {
                switch (line.Substring(i, 1))
                {
                    case "e":
                        x += 2;
                        continue;
                    case "w":
                        x -= 2;
                        continue;
                }

                switch (line.Substring(i, 2))
                {
                    case "nw":
                        x--;
                        y--;
                        i++;
                        continue;
                    case "ne":
                        x++;
                        y--;
                        i++;
                        continue;
                    case "se":
                        x++;
                        y++;
                        i++;
                        continue;
                    case "sw":
                        x--;
                        y++;
                        i++;
                        continue;
                }
            }

            var key = GetKey(x, y);
            if (tiles.ContainsKey(key))
                tiles[key]++;
            else
                tiles[key] = 1;
        }

        if (part == 1) return GetBlack(tiles);

        AddNeighbors(tiles);

        var iterations = 0;
        while (iterations < 100)
        {
            var toFlip = new List<string>();
            foreach (var tile in tiles)
            {
                var neighbors = GetNeighbors(tiles, GetX(tile), GetY(tile));
                var blackCount = GetBlack(neighbors);

                if (tile.Value % 2 == 1)
                {
                    if (blackCount == 0 || blackCount > 2) toFlip.Add(tile.Key);
                }
                else
                {
                    if (blackCount == 2) toFlip.Add(tile.Key);
                }
            }

            foreach (var tile in toFlip) tiles[tile]++;
            AddNeighbors(tiles);
            iterations++;
        }

        return GetBlack(tiles);
    }

    private static int GetX(in KeyValuePair<string, int> tile)
    {
        return int.Parse(tile.Key.Split("#")[0]);
    }

    private static int GetY(in KeyValuePair<string, int> tile)
    {
        return int.Parse(tile.Key.Split("#")[1]);
    }

    private static string GetKey(int x, int y)
    {
        return x + "#" + y;
    }

    private static void AddNeighbors(Dictionary<string, int> tiles)
    {
        foreach (var tile in tiles.Where(x => x.Value % 2 == 1).ToList())
        {
            var neighbors = GetNeighbors(tiles, int.Parse(tile.Key.Split("#")[0]), int.Parse(tile.Key.Split("#")[1]));
            foreach (var neighbor in neighbors)
                if (!tiles.ContainsKey(neighbor.Key))
                    tiles[neighbor.Key] = 0;
        }
    }

    private static int GetBlack(Dictionary<string, int> tiles)
    {
        return tiles.Count(x => x.Value % 2 == 1);
    }

    private static Dictionary<string, int> GetNeighbors(Dictionary<string, int> tiles, int x, int y)
    {
        var result = new Dictionary<string, int>();

        foreach (var neighbour in Neighbours)
        {
            var neighbourKey = GetKey(x + neighbour.X, y + neighbour.Y);

            if (tiles.ContainsKey(neighbourKey))
                result[neighbourKey] = tiles[neighbourKey];
            else
                result[neighbourKey] = 0;
        }

        return result;
    }
}