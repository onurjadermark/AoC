using System.Numerics;

namespace Solutions.Solutions._2021;

public class Day19
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
        var scanners = ParseInput(input);
        var foundBeacons = new HashSet<Vector3>(scanners[0]);
        var allScannerVariants = scanners.Skip(1).Select(GetVariants).ToList()!;
        var scannerLocations = new List<Vector3> {new(0, 0, 0)};

        while (allScannerVariants.Any())
        {
            var maxMatched = int.MinValue;
            Vector3 matchedFoundBeacon = default;
            Vector3 matchedVariantBeacon = default;
            HashSet<HashSet<Vector3>> variantsToRemove = new();
            int matchedXDiff = 0, matchedYDiff = 0, matchedZDiff = 0;

            var sortedFoundBeacons = foundBeacons.OrderBy(x => x.X).ToList();
            foreach (var scannerVariants in allScannerVariants)
            {
                foreach (var scannerVariant in scannerVariants)
                {
                    var sortedScannerVariant = scannerVariant.OrderBy(x => x.X).ToList();
                    for (var i = 0; i < sortedScannerVariant.Count; i++)
                    {
                        var variantBeacon = sortedScannerVariant[i];
                        for (var j = 0; j < sortedFoundBeacons.Count; j++)
                        {
                            var foundBeacon = sortedFoundBeacons[j];
                            var xDiff = (int) (variantBeacon.X - foundBeacon.X);
                            var yDiff = (int) (variantBeacon.Y - foundBeacon.Y);
                            var zDiff = (int) (variantBeacon.Z - foundBeacon.Z);

                            if (i + 1 < sortedScannerVariant.Count && j + 1 < sortedFoundBeacons.Count &&
                                (int) sortedScannerVariant[i + 1].X - (int) sortedFoundBeacons[j + 1].X != xDiff)
                                continue;

                            var matched = foundBeacons.IntersectBy(scannerVariant,
                                x => new Vector3(x.X + xDiff, x.Y + yDiff, x.Z + zDiff)).Count();
                            if (matched > maxMatched)
                            {
                                maxMatched = matched;
                                variantsToRemove = scannerVariants;
                                matchedFoundBeacon = foundBeacon;
                                matchedVariantBeacon = variantBeacon;
                                matchedXDiff = xDiff;
                                matchedYDiff = yDiff;
                                matchedZDiff = zDiff;
                            }
                        }
                    }
                }

                if (maxMatched > 3) break;
            }

            allScannerVariants.Remove(variantsToRemove);
            var variants = variantsToRemove.First(x => x.Contains(matchedVariantBeacon));
            var variantBeacons =
                variants.Select(x => new Vector3(x.X - matchedXDiff, x.Y - matchedYDiff, x.Z - matchedZDiff));
            variantBeacons.Where(x => !foundBeacons.Contains(x)).ToList().ForEach(x => foundBeacons.Add(x));
            scannerLocations.Add(new Vector3(matchedFoundBeacon.X - matchedVariantBeacon.X,
                matchedFoundBeacon.Y - matchedVariantBeacon.Y,
                matchedFoundBeacon.Z - matchedVariantBeacon.Z));
        }

        var maxDistance = 0;
        foreach (var scanner1 in scannerLocations)
        foreach (var scanner2 in scannerLocations)
        {
            if (scanner1 == scanner2) continue;
            var distance = Math.Abs(scanner1.X - scanner2.X) + Math.Abs(scanner1.Y - scanner2.Y) +
                           Math.Abs(scanner1.Z - scanner2.Z);
            if (distance > maxDistance) maxDistance = (int) distance;
        }

        return part == 1 ? foundBeacons.Count : maxDistance;
    }

    private HashSet<HashSet<Vector3>> GetVariants(HashSet<Vector3> scanner)
    {
        var variants = new HashSet<HashSet<Vector3>>();
        for (var i = 0; i < 6; i++)
        for (var j = 0; j < 4; j++)
            variants.Add(scanner.Select(x => Rotate(Transform(x, i), j)).ToHashSet());

        return variants;
    }

    private Vector3 Rotate(Vector3 pos, int rotation)
    {
        return rotation switch
        {
            0 => new Vector3(pos.X, pos.Y, pos.Z),
            1 => new Vector3(-pos.X, pos.Y, -pos.Z),
            2 => new Vector3(pos.Z, pos.Y, -pos.X),
            3 => new Vector3(-pos.Z, pos.Y, pos.X),
            _ => throw new InvalidOperationException()
        };
    }

    private Vector3 Transform(Vector3 pos, int direction)
    {
        return direction switch
        {
            0 => new Vector3(pos.X, pos.Y, pos.Z),
            1 => new Vector3(pos.X, pos.Z, -pos.Y),
            2 => new Vector3(pos.X, -pos.Y, -pos.Z),
            3 => new Vector3(pos.X, -pos.Z, pos.Y),
            4 => new Vector3(pos.Y, -pos.X, pos.Z),
            5 => new Vector3(-pos.Y, pos.X, pos.Z),
            _ => throw new InvalidOperationException()
        };
    }

    private static List<HashSet<Vector3>> ParseInput(string[] input)
    {
        var scanners = new List<HashSet<Vector3>>();
        HashSet<Vector3> scanner = new();
        foreach (var line in input)
        {
            if (line.StartsWith("---"))
            {
                scanner = new HashSet<Vector3>();
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                scanners.Add(scanner);
                continue;
            }

            var split = line.Split(",").Select(int.Parse).ToList();
            scanner.Add(new Vector3(split[0], split[1], split[2]));
        }

        scanners.Add(scanner);
        return scanners;
    }
}