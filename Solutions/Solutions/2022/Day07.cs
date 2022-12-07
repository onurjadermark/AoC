namespace Solutions.Solutions._2022;

public class Day07
{
    public int Part1(string[] input)
    {
        var allDirectories = ParseFileSystem(input);
        return allDirectories.Where(x => x.TotalSize < 100000).Sum(x => x.TotalSize);
    }

    public int Part2(string[] input)
    {
        var allDirectories = ParseFileSystem(input);
        var currentDirectory = allDirectories.Single(x => x.Parent == null);
        var emptySpace = 70000000 - currentDirectory.TotalSize;
        return allDirectories.OrderBy(x => x.TotalSize).First(x => x.TotalSize > 30000000 - emptySpace).TotalSize;
    }

    private static List<Directory> ParseFileSystem(string[] input)
    {
        var allDirectories = new List<Directory>();
        var currentDirectory = new Directory("/", null);
        allDirectories.Add(currentDirectory);
        for (var i = 1; i < input.Length; i++)
        {
            var lineParts = input[i].Split(" ");
            switch (lineParts[1])
            {
                case "cd":
                    currentDirectory = lineParts[2] == ".."
                        ? currentDirectory!.Parent
                        : currentDirectory!.Children.Single(x => x.Name == lineParts[2]);
                    break;
                case "ls":
                {
                    while (true)
                    {
                        if (i >= input.Length - 1) break;

                        lineParts = input[i + 1].Split(" ");
                        if (lineParts[0] == "dir")
                        {
                            var directory = new Directory(lineParts[1], currentDirectory);
                            allDirectories.Add(directory);
                            currentDirectory!.Children.Add(directory);
                        }
                        else if (lineParts[0] != "$")
                        {
                            currentDirectory!.Files.Add(new File(int.Parse(lineParts[0])));
                        }
                        else
                        {
                            break;
                        }

                        i++;
                    }

                    break;
                }
            }
        }

        return allDirectories;
    }

    private class Directory
    {
        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; }
        public Directory? Parent { get; }
        public List<Directory> Children { get; } = new();
        public List<File> Files { get; } = new();

        public int TotalSize => GetSize(this, 0);

        private int GetSize(Directory currentDirectory, int size)
        {
            size += currentDirectory.Files.Sum(x => x.Size);
            size += currentDirectory.Children.Sum(x => GetSize(x, 0));
            return size;
        }
    }

    private class File
    {
        public File(int size)
        {
            Size = size;
        }

        public int Size { get; }
    }
}