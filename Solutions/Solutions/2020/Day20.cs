namespace Solutions.Solutions._2020;

public class Day20
{
    public long Part1(string input)
    {
        return Solve(input, 1);
    }

    public long Part2(string input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string input, int part)
    {
        var inputTiles = input.Split("\r\n\r\n").Select(x => x.Trim()).ToList();
        var tiles = new List<Tile>();
        foreach (var inputTile in inputTiles) tiles.Add(new Tile(inputTile));

        var corners = new HashSet<Tile>();
        foreach (var tile1 in tiles)
        {
            var countNoMatch = 0;
            foreach (var tile1Edge in tile1.Edges)
            {
                var hasMatch = false;
                var tile1EdgeReverse = string.Join("", tile1Edge.Reverse());
                foreach (var tile2 in tiles)
                {
                    if (tile2 == tile1) continue;
                    foreach (var tile2Edge in tile2.Edges)
                        if (tile2Edge == tile1Edge || tile2Edge == tile1EdgeReverse)
                        {
                            hasMatch = true;
                            tile1.Neighbors.Add(tile2);
                            tile2.Neighbors.Add(tile1);
                        }
                }

                if (!hasMatch)
                {
                    countNoMatch++;
                    tile1.OutsideEdges.Add(tile1Edge);
                }
            }

            if (countNoMatch > 1) corners.Add(tile1);
        }

        long result = 1;
        foreach (var x in corners) result *= x.Id;

        if (part == 1) return result;

        var tileSize = tiles.First().Edges.First().Length;
        var edgeTilesCount = (int) Math.Sqrt(tiles.Count);

        var orderedTiles = new Tile[edgeTilesCount, edgeTilesCount];
        var corner = corners.First();
        corner.Flip();
        while (!corner.OutsideEdges.All(x =>
                   x == corner.GetTop() || x == corner.GetLeft() ||
                   x == string.Join("", corner.GetTop().Reverse()) || x == string.Join("", corner.GetLeft().Reverse())))
            corner.Rotate();
        orderedTiles[0, 0] = corner;

        for (var j = 0; j < edgeTilesCount; j++)
        {
            if (orderedTiles[0, j] == null)
            {
                var topTile = orderedTiles[0, j - 1];

                var nextTile = tiles.SingleOrDefault(x => x != topTile && x.Edges.Any(y => y == topTile.GetBottom()));
                if (nextTile == null)
                    nextTile = tiles.Single(x =>
                        x != topTile && x.Edges.Any(y => y == string.Join("", topTile.GetBottom().Reverse())));
                else
                    nextTile.Flip();

                while (nextTile.GetTop() != string.Join("", topTile.GetBottom().Reverse())) nextTile.Rotate();

                orderedTiles[0, j] = nextTile;
            }

            for (var i = 1; i < edgeTilesCount; i++)
            {
                var leftTile = orderedTiles[i - 1, j];

                var nextTile = tiles.SingleOrDefault(x => x != leftTile && x.Edges.Any(y => y == leftTile.GetRight()));
                if (nextTile == null)
                    nextTile = tiles.Single(x =>
                        x != leftTile && x.Edges.Any(y => y == string.Join("", leftTile.GetRight().Reverse())));
                else
                    nextTile.Flip();

                while (nextTile.GetLeft() != string.Join("", leftTile.GetRight().Reverse())) nextTile.Rotate();

                orderedTiles[i, j] = nextTile;
            }
        }

        var size = edgeTilesCount * (tileSize - 2);
        var image = new bool[size, size];
        for (var j = 0; j < edgeTilesCount; j++)
        for (var i = 0; i < edgeTilesCount; i++)
        {
            var currentTile = orderedTiles[i, j];
            for (var k = 1; k < tileSize - 1; k++)
            for (var l = 1; l < tileSize - 1; l++)
                image[i * (tileSize - 2) + l - 1, j * (tileSize - 2) + k - 1] =
                    currentTile.Data.ElementAt(k).ElementAt(l) == '#';
        }

        var monster = new[]
        {
            "                  # ",
            "#    ##    ##    ###",
            " #  #  #  #  #  #   "
        };
        var coordinates = new List<(int X, int Y)>();

        var rotateCount = 0;
        while (true)
        {
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
            {
                var valid = true;
                for (var k = 0; k < 3; k++)
                {
                    if (!valid) break;
                    for (var l = 0; l < 20; l++)
                    {
                        if (!valid) break;
                        if (monster[k].ElementAt(l) == '#')
                        {
                            if (i + l >= size) valid = false;
                            if (j + k >= size) valid = false;
                            if (!valid) break;
                            if (!image[i + l, j + k]) valid = false;
                        }
                    }
                }

                if (valid) coordinates.Add((i, j));
            }

            if (coordinates.Any()) break;

            var newImage = new bool[size, size];
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
                newImage[i, j] = image[j, size - i - 1];
            image = newImage;

            if (rotateCount == 8) throw new Exception();
            rotateCount++;
            if (rotateCount == 4)
            {
                var newImage2 = new bool[size, size];
                for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    newImage2[i, j] = image[i, size - j - 1];

                image = newImage2;
            }
        }

        var monsterImage = new bool[size, size];
        foreach (var coordinate in coordinates)
            for (var j = 0; j < 3; j++)
            for (var i = 0; i < 20; i++)
                if (monster.ElementAt(j).ElementAt(i) == '#')
                {
                    if (!image[coordinate.X + i, coordinate.Y + j]) throw new Exception();
                    monsterImage[coordinate.X + i, coordinate.Y + j] = true;
                }

        result = 0;
        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            if (image[i, j] && !monsterImage[i, j])
                result++;

        return result;
    }

    private class Tile
    {
        public Tile(string inputTile)
        {
            var split = inputTile.Split("\n").Select(x => x.Trim()).ToList();
            Id = int.Parse(split[0].Replace(":", "").Split(" ")[1]);
            Edges.Add(split[1]);
            Edges.Add(string.Join("", split.Skip(1).Select(x => x.Last())));
            Edges.Add(string.Join("", split[^1].Reverse()));
            Edges.Add(string.Join("", split.Skip(1).Select(x => x.First()).Reverse()));
            foreach (var line in split.Skip(1)) Data.Add(line);
        }

        public long Id { get; }
        public List<string> Data { get; private set; } = new();
        public HashSet<string> Edges { get; } = new();
        public HashSet<string> OutsideEdges { get; } = new();
        public HashSet<Tile> Neighbors { get; } = new();

        public string GetTop()
        {
            return Data.First();
        }

        public string GetRight()
        {
            return string.Join("", Data.Select(x => x.Last()));
        }

        public string GetBottom()
        {
            return string.Join("", Data.Last().Reverse());
        }

        public string GetLeft()
        {
            return string.Join("", Data.Select(x => x.First()).Reverse());
        }

        public void Rotate()
        {
            var newData = new List<string>();
            for (var i = 0; i < Data.Count; i++)
            {
                var newRow = string.Join("", Data.SelectMany(x => x.Skip(i).Take(1).ToList()).Reverse());
                newData.Add(newRow);
            }

            Data = newData;
        }

        public void Flip()
        {
            Data = Data.Select(x => string.Join("", x.Reverse())).ToList();
        }
    }
}